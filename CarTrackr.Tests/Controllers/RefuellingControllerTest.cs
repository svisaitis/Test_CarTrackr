using CarTrackr.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using CarTrackr.Repository;
using System.Web.Mvc;
using System;
using CarTrackr.Tests.Helpers;
using CarTrackr.Tests.Repository;
using CarTrackr.Models;

namespace CarTrackr.Tests.Controllers
{
    
    
    /// <summary>
    ///This is a test class for RefuellingControllerTest and is intended
    ///to contain all RefuellingControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RefuellingControllerTest
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
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            // Setup
            DataStore dataStore = new DataStore();
            IUserRepository userRepository = new CarTrackr.Tests.Repository.UserRepository(dataStore);
            ICarRepository carRepository = new CarTrackr.Tests.Repository.CarRepository(dataStore);
            IRefuellingRepository refuellingRepository = new CarTrackr.Tests.Repository.RefuellingRepository(dataStore);

            RefuellingController target = new RefuellingController(userRepository, carRepository, refuellingRepository);

            // Execute
            Guid id = dataStore.Refuellings[0].Id;

            RedirectToRouteResult result = target.Remove(id) as RedirectToRouteResult;

            // Verify
            Assert.IsNull(refuellingRepository.RetrieveById(id));
        }

        /// <summary>
        ///A test for New
        ///</summary>
        [TestMethod()]
        public void NewTest1()
        {
            // Setup
            DataStore dataStore = new DataStore();
            IUserRepository userRepository = new CarTrackr.Tests.Repository.UserRepository(dataStore);
            ICarRepository carRepository = new CarTrackr.Tests.Repository.CarRepository(dataStore);
            IRefuellingRepository refuellingRepository = new CarTrackr.Tests.Repository.RefuellingRepository(dataStore);

            RefuellingController target = new RefuellingController(userRepository, carRepository, refuellingRepository);

            // Execute
            string licensePlate = "testplate1";

            ViewResult result = target.New(licensePlate) as ViewResult;
            
            // Verify
            Assert.AreEqual(
                carRepository.RetrieveByLicensePlate(licensePlate),
                ((NewRefuellingViewData)result.ViewData.Model).Car
            );
        }

        /// <summary>
        ///A test for New
        ///</summary>
        [TestMethod()]
        public void NewTest2()
        {
            // Setup
            DataStore dataStore = new DataStore();
            IUserRepository userRepository = new CarTrackr.Tests.Repository.UserRepository(dataStore);
            ICarRepository carRepository = new CarTrackr.Tests.Repository.CarRepository(dataStore);
            carRepository.User = userRepository.RetrieveByUserName("testuser1");
            IRefuellingRepository refuellingRepository = new CarTrackr.Tests.Repository.RefuellingRepository(dataStore);

            RefuellingController target = new RefuellingController(userRepository, carRepository, refuellingRepository);
            target.SetFakeControllerContext();
            target.Request.SetHttpMethodResult("POST");

            // Execute
            string licensePlate = "testplate1";
            FormCollection formCollection = new FormCollection();
            formCollection.Add("Date",DateTime.Now.ToString());
            formCollection.Add("ServiceStation","teststation3");
            formCollection.Add("Kilometers", "300");
            formCollection.Add("Liters", "100");
            formCollection.Add("PricePerLiter", "2");
            formCollection.Add("Total", "200");
            formCollection.Add("Usage", "100");

            RedirectToRouteResult result = target.New(licensePlate, formCollection) as RedirectToRouteResult;

            // Verify
            Assert.AreEqual(3,
                refuellingRepository.List(
                    carRepository.RetrieveByLicensePlate(licensePlate)
                ).Count
            );
        }
    }
}
