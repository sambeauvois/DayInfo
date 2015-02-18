using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Threading;
using DayInfo.Extensions;

namespace DayInfo.Tests
{
    /// <summary>
    /// Summary description for DayInfoTests
    /// </summary>
    [TestClass]
    public class DayInfoTests
    {
        public DayInfoTests()
        {
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }

        public void CountryTest(string countrycode)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            var dinfos = DayInfo.All(countrycode);
            Assert.IsNotNull(dinfos);
            CollectionAssert.AllItemsAreNotNull(dinfos.ToList());
            TestContext.WriteLine("{0} : {1} day off", countrycode, dinfos.Count());
            foreach (var day in dinfos)
            {
                TestContext.WriteLine("{0} {1}", day.DisplayName, day.Name);
                if (day.DisplayInfoURLs != null)
                {
                    foreach (var d in day.DisplayInfoURLs)
                    {
                        TestContext.WriteLine(" {2} {0} {1}", d.Title, d.URL, day.DisplayName);
                    }
                }
            }

            TestContext.WriteLine("------------------");
            var dates = DateInfo.Get(countrycode, 2014).OrderBy(x => x.Date);
            Assert.IsNotNull(dates);
            CollectionAssert.AllItemsAreNotNull(dates.ToList());
            foreach (var dat in dates)
            {
                TestContext.WriteLine("{0} {2:D} {1} ", dat.DayInfo.DisplayName, dat.DayInfo.DisplayDescription, dat.Date);
            }
        }

        [TestMethod]
        public void BelgiumDaysTest()
        {
            CountryTest("BE");
        }

        [TestMethod]
        public void LuxembourgDaysTest()
        {
            CountryTest("LU");
        }

        [TestMethod]
        public void FranceDaysTest()
        {

            CountryTest("FR");
        }

        [TestMethod]
        public void UnitedKingdomDaysTest()
        {
            CountryTest("UK");
        }

        [TestMethod]
        public void CulturesTest()
        {
            foreach (var cu in CultureInfo.GetCultures(CultureTypes.AllCultures).OrderBy(x => x.Name))
            {
                try
                {
                    RegionInfo re = new RegionInfo(cu.LCID);
                    TestContext.WriteLine("{0} : {1} -- {2} : {3}", cu.TwoLetterISOLanguageName, cu.DisplayName, re.TwoLetterISORegionName, re.DisplayName);
                    var days = re.GetDays();
                    if (days.Any())
                    {
                        TestContext.WriteLine("*******{0} days for {1} ({2})", days.Count(), re.DisplayName, re.TwoLetterISORegionName);
                    }
                }
                catch { }
            }

        }
    }
}
