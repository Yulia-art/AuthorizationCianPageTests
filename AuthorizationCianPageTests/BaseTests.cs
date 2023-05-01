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
            //chromeOptions.AddArguments(new List<string>() { "headless", "disable-gpu" }); //start-fullscreen = f11 //headless incognito
            chromeOptions.AddArguments(new List<string>() {
                                "--silent-launch",
                                "--no-startup-window",
                                "no-sandbox",
                                "headless",});
            //driver = new ChromeDriver(chromeOptions);
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;    // This is to hidden the console.
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Navigate().GoToUrl(TestSettings.HostPrefix);

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
