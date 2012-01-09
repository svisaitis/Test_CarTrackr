using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using DotNetOpenId.RelyingParty;
using DotNetOpenId;

namespace CarTrackr.Controllers
{

    [HandleError]
    [OutputCache(Location = OutputCacheLocation.None)]
    public class AccountController : Controller
    {

        public AccountController()
            : this(null, null)
        {
        }

        public AccountController(IFormsAuthentication formsAuth, MembershipProvider provider)
        {
            FormsAuth = formsAuth ?? new FormsAuthenticationWrapper();
            Provider = provider ?? Membership.Provider;
        }

        public IFormsAuthentication FormsAuth
        {
            get;
            private set;
        }

        public MembershipProvider Provider
        {
            get;
            private set;
        }

        [Authorize]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {

            ViewData["Title"] = "Change Password";
            ViewData["PasswordLength"] = Provider.MinRequiredPasswordLength;

            // Non-POST requests should just display the ChangePassword form 
            if (Request.HttpMethod != "POST")
            {
                return View();
            }

            // Basic parameter validation
            if (String.IsNullOrEmpty(currentPassword))
            {
                ViewData.ModelState.AddModelError("currentPassword", "You must specify a current password.");
            }
            if (newPassword == null || newPassword.Length < Provider.MinRequiredPasswordLength)
            {
                ViewData.ModelState.AddModelError("newPassword", String.Format(CultureInfo.InvariantCulture,
                         "You must specify a new password of {0} or more characters.",
                         Provider.MinRequiredPasswordLength));
            }
            if (!String.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                ViewData.ModelState.AddModelError("confirmPassword", "The new password and confirmation password do not match.");
            }

            if (ViewData.ModelState.IsValid)
            {

                // Attempt to change password
                MembershipUser currentUser = Provider.GetUser(User.Identity.Name, true /* userIsOnline */);
                bool changeSuccessful = false;
                try
                {
                    changeSuccessful = currentUser.ChangePassword(currentPassword, newPassword);
                }
                catch
                {
                    // An exception is thrown if the new password does not meet the provider's requirements
                }

                if (changeSuccessful)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ViewData.ModelState.AddModelError("Password", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        public ActionResult ChangePasswordSuccess()
        {

            ViewData["Title"] = "Change Password";

            return View();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password, bool? rememberMe)
        {

            ViewData["Title"] = "Login";

            // Non-POST requests should just display the Login form 
            if (Request.HttpMethod != "POST")
            {
                return View();
            }

            // Basic parameter validation
            if (String.IsNullOrEmpty(username))
            {
               ViewData.ModelState.AddModelError("username", "You must specify a username.");
            }

            if (ViewData.ModelState.IsValid)
            {

                // Attempt to login
                bool loginSuccessful = Provider.ValidateUser(username, password);

                if (loginSuccessful)
                {

                    FormsAuth.SetAuthCookie(username, rememberMe ?? false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData.ModelState.AddModelError("password", "The username or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["username"] = username;
            return View();
        }

        public ActionResult Logout()
        {

            FormsAuth.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }
        }

        public ActionResult Register(string username, string email, string password, string confirmPassword)
        {

            ViewData["Title"] = "Register";
            ViewData["PasswordLength"] = Provider.MinRequiredPasswordLength;

            // Non-POST requests should just display the Register form 
            if (Request.HttpMethod != "POST")
            {
                return View();
            }

            // Basic parameter validation
            if (String.IsNullOrEmpty(username))
            {
                ViewData.ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData.ModelState.AddModelError("email", "You must specify an email address.");
            }
            if (password == null || password.Length < Provider.MinRequiredPasswordLength)
            {
                ViewData.ModelState.AddModelError("password", String.Format(CultureInfo.InvariantCulture,
                         "You must specify a password of {0} or more characters.",
                         Provider.MinRequiredPasswordLength));
            }
            if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                ViewData.ModelState.AddModelError("confirmPassword", "The password and confirmation do not match.");
            }

            if (ViewData.ModelState.IsValid)
            {

                // Attempt to register the user
                MembershipCreateStatus createStatus;
                MembershipUser newUser = Provider.CreateUser(username, password, email, null, null, true, null, out createStatus);

                if (newUser != null)
                {

                    FormsAuth.SetAuthCookie(username, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData.ModelState.AddModelError("Error", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["username"] = username;
            ViewData["email"] = email;
            return View();
        }

        [HandleError(ExceptionType = typeof(OpenIdException))]
        [HandleError(ExceptionType = typeof(System.Net.WebException))]
        public virtual ActionResult OpenIdLogin(string openid_identifier)
        {
            bool rememberMe = false;
            OpenIdRelyingParty openid = new OpenIdRelyingParty();

            // Stage 1: display login form to user
            if (openid.Response == null && Request.HttpMethod != "POST")
            {
                return View("Login");
            } else
            if (openid.Response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(openid_identifier, out id))
                {
                    openid.CreateRequest(openid_identifier).RedirectToProvider();
                }
                else
                {
                    ViewData.ModelState.AddModelError("openid_identifier", ErrorMessages.InvalidIdentifierSpecified);
                    ViewData["openid_identifier"] = openid_identifier;
                    return View("Login");
                }
            }
            else
            {
                // Stage 3: OpenID Provider sending assertion response
                switch (openid.Response.Status)
                {
                    case AuthenticationStatus.Authenticated:

                        // Associate openid identity to user account and login
                        var userName = AssociateOpenIdIdentityToUserName(openid.Response.ClaimedIdentifier);
                        if (string.IsNullOrEmpty(userName))
                        {
                            ViewData.ModelState.AddModelError("openid_identifier", ErrorMessages.AssociationFailure);
                            ViewData["openid_identifier"] = openid.Response.ClaimedIdentifier;
                            return View("Login");
                        }
                        FormsAuthentication.RedirectFromLoginPage(userName, rememberMe);
                        break;

                    case AuthenticationStatus.Canceled:
                        ViewData.ModelState.AddModelError("openid_identifier", ErrorMessages.CanceledAtProvider);
                        ViewData["openid_identifier"] = openid.Response.ClaimedIdentifier;
                        return View("Login");

                    case AuthenticationStatus.Failed:
                        ViewData.ModelState.AddModelError("openid_identifier", ErrorMessages.UnknownFailure + openid.Response.Exception.Message);
                        ViewData["openid_identifier"] = openid.Response.ClaimedIdentifier;
                        return View("Login");
                }
            }

            return View("Login");
        }

        public virtual ViewResult XRDS()
        {
            return View();
        }

        protected string AssociateOpenIdIdentityToUserName(string openIdIdentity)
        {
            // Try to get user
            MembershipUser user = Provider.GetUser(openIdIdentity, true);

            // If we didn't find user, create a new one
            if (user == null)
            {
                string password = Guid.NewGuid().ToString();

                MembershipCreateStatus status;
                user = Membership.CreateUser(openIdIdentity, password, password + "@example.com", password, password, true, out status);

                if (status != MembershipCreateStatus.Success)
                    throw new MembershipCreateUserException(status.ToString());
            }

            return (user == null ? null : user.UserName);
        }

        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://msdn.microsoft.com/en-us/library/system.web.security.membershipcreatestatus.aspx for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }

    #region Nested type: ErrorMessages

    public struct ErrorMessages
    {
        public static string AssociationFailure = "Could not associate OpenID to a user in this system.";
        public static string CanceledAtProvider = "Login canceled by OpenID provider.";
        public static string InvalidIdentifierSpecified = "You must specify an OpenID Url.";
        public static string InvalidIdentityServerSpecified = "OpenID provider not on whitelist.";
        public static string UnknownFailure = "OpenID authentication failed: ";
    }

    #endregion

    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IFormsAuthentication
    {
        void SetAuthCookie(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationWrapper : IFormsAuthentication
    {
        public void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
