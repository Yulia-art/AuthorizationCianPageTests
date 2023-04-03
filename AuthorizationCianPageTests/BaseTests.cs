using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests
{
    public class BaseTests
    {
        protected IWebDriver driver;
        protected EnviromentConstants enviromentConstants;

        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito"); //start-fullscreen = f11
            driver = new ChromeDriver(chromeOptions);

            InitializeData();
        }

        [OneTimeTearDown]
        protected void DoAfterAllTests()
        {

        }

        [TearDown]
        protected void DoAfterEachTest()
        {
            driver.Quit();
        }

        [SetUp]
        protected void DoBeforeEachTest()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(TestSettings.HostPrefix);
            driver.Manage().Window.Maximize();
            WaitUntil.ShouldLocate(driver, TestSettings.LocationCian);
        }

        private void InitializeData()
        {
            new EnviromentConstantsProvider().Provide(out EnviromentConstants enviromentConstantsObject);
            enviromentConstants = enviromentConstantsObject;
        }
    }
}
