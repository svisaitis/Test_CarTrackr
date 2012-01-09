using CarTrackr.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using System.Web.Security;
using System;
using Moq;
using CarTrackr.Tests.Helpers;
using System.Collections.Generic;

namespace CarTrackr.Tests.Controllers
{
    
    
    /// <summary>
    ///This is a test class for AccountControllerTest and is intended
    ///to contain all AccountControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccountControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Register
        ///</summary>
        [TestMethod()]
        public void RegisterTest1()
        {
            // Setup
            var formsAuthenticationMock = new Mock<IFormsAuthentication>();
            var membershipProviderMock = new Mock<MembershipProvider>();

            AccountController target = new AccountController(formsAuthenticationMock.Object, membershipProviderMock.Object);
            target.SetFakeControllerContext();

            // Execute
            ViewResult result = target.Register(null, null, null, null) as ViewResult;

            // Verify
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Register", viewData["Title"]);
            Assert.AreEqual(2, viewData.Count);
        }

        /// <summary>
        ///A test for Register
        ///</summary>
        [TestMethod()]
        public void RegisterTest2()
        {
            // Setup
            var formsAuthenticationMock = new Mock<IFormsAuthentication>();
            var membershipProviderMock = new Mock<MembershipProvider>();

            AccountController target = new AccountController(formsAuthenticationMock.Object, membershipProviderMock.Object);
            target.SetFakeControllerContext();
            target.HttpContext.Request.SetHttpMethodResult("POST");

            // Execute
            string username = "";
            string email = "test@example.com";
            string password = "testing123";
            string confirmPassword = "testing123";

            ViewResult result = target.Register(username, email, password, confirmPassword) as ViewResult;

            // Verify
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Register", viewData["Title"]);
            Assert.IsFalse(viewData.ModelState.IsValid);
            Assert.AreEqual(1, viewData.ModelState.Count);
        }

        /// <summary>
        ///A test for Register
        ///</summary>
        [TestMethod()]
        public void RegisterTest3()
        {
            // Setup
            var formsAuthenticationMock = new Mock<IFormsAuthentication>();
            var membershipProviderMock = new Mock<MembershipProvider>();

            MembershipCreateStatus status = MembershipCreateStatus.Success;
            membershipProviderMock
                .Expect(m => m.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), true, It.IsAny<object>(), out status))
                .Returns(new MembershipUser("AspNetSqlMembershipProvider", "", null, "", "", "", true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.MinValue));

            AccountController target = new AccountController(formsAuthenticationMock.Object, membershipProviderMock.Object);
            target.SetFakeControllerContext();
            target.HttpContext.Request.SetHttpMethodResult("POST");

            // Execute
            string username = "testing";
            string email = "test@example.com";
            string password = "testing123";
            string confirmPassword = "testing123";

            RedirectToRouteResult result = target.Register(username, email, password, confirmPassword) as RedirectToRouteResult;
        }

        /// <summary>
        ///A test for Logout
        ///</summary>
        [TestMethod()]
        public void LogoutTest()
        {
            // Setup
            var formsAuthenticationMock = new Mock<IFormsAuthentication>();
            var membershipProviderMock = new Mock<MembershipProvider>();

            formsAuthenticationMock.Expect(f => f.SignOut()).AtMostOnce();

            AccountController target = new AccountController(formsAuthenticationMock.Object, membershipProviderMock.Object);
            target.SetFakeControllerContext();

            // Execute
            RedirectToRouteResult result = target.Logout() as RedirectToRouteResult;
        }

        /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest1()
        {
            // Setup
            var formsAuthenticationMock = new Mock<IFormsAuthentication>();
            var membershipProviderMock = new Mock<MembershipProvider>();

            AccountController target = new AccountController(formsAuthenticationMock.Object, membershipProviderMock.Object);
            target.SetFakeControllerContext();

            // Execute
            ViewResult result = target.Login(null, null, null) as ViewResult;

            // Verify
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Login", viewData["Title"]);
            Assert.AreEqual(1, viewData.Count);
        }

        /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest2()
        {
            // Setup
            var formsAuthenticationMock = new Mock<IFormsAuthentication>();
            var membershipProviderMock = new Mock<MembershipProvider>();

            formsAuthenticationMock.Expect(f => f.SetAuthCookie(It.IsAny<string>(), true)).AtMostOnce();

            membershipProviderMock
                .Expect(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);

            AccountController target = new AccountController(formsAuthenticationMock.Object, membershipProviderMock.Object);
            target.SetFakeControllerContext();
            target.HttpContext.Request.SetHttpMethodResult("POST");

            // Execute
            ViewResult result = target.Login(null, null, null) as ViewResult;

            // Verify
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Login", viewData["Title"]);
            Assert.IsFalse(viewData.ModelState.IsValid);
            Assert.AreEqual(1, viewData.ModelState.Count);
        }

        /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest3()
        {
            // Setup
            var formsAuthenticationMock = new Mock<IFormsAuthentication>();
            var membershipProviderMock = new Mock<MembershipProvider>();

            formsAuthenticationMock.Expect(f => f.SetAuthCookie(It.IsAny<string>(), true)).AtMostOnce();

            membershipProviderMock
                .Expect(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            AccountController target = new AccountController(formsAuthenticationMock.Object, membershipProviderMock.Object);
            target.SetFakeControllerContext();
            target.HttpContext.Request.SetHttpMethodResult("POST");

            // Execute
            string username = "testing";
            string password = "testing123";
            Nullable<bool> rememberMe = true;

            // Execute
            RedirectToRouteResult result = target.Login(username, password, rememberMe) as RedirectToRouteResult;
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            LoginTest1();
        }
    }
}
