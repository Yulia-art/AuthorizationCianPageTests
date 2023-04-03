using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver driver;

        private readonly By _signInButton = By.XPath("//span[text()='Войти']");
        private readonly By _switchToEmailButton = By.XPath("//button[@data-name='SwitchToEmailAuthBtn']");
        private readonly By _userAvatarButton = By.XPath("//*[@data-name='UserAvatar']");
        private readonly By _userLogin = By.XPath("//*[contains(@class, 'user-name')]");
        private readonly By _tabsXPath = By.XPath("//*[@data-name='NavBar']");
        private readonly By _directoryOfSpecialists = By.CssSelector("a[href='/agentstva/']");
        private readonly By _magazineTab = By.CssSelector("a[href='/magazine/']");

        public MainMenuPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AuthorizationPageObject SignIn()
        {
            driver.FindElement(_signInButton).Click();
            driver.FindElement(_switchToEmailButton).Click();

            return new AuthorizationPageObject(driver);
        }

        public string GetUserLogin()
        {
            WaitUntil.WaitForElement(driver, _userAvatarButton);
            driver.FindElement(_userAvatarButton).Click();
            WaitUntil.WaitForElement(driver, _userLogin);
            string userLogin = driver.FindElement(_userLogin).Text;

            WaitUntil.WaitForElement(driver, _userLogin);

            return userLogin;
        }

        public bool CheckElementPresent_FirstWay(string xPath)
        {
            try
            {
                driver.FindElement(By.CssSelector(xPath));
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }

        public bool CheckElementPresent_SecondWay(string element)
        {
            try
            {
                driver.PageSource.Contains(element);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool CheckELementPresent_ThirdWay =>
            driver.PageSource.Contains("snyat");

        public MainMenuPageObject NavigateToTab(string xPath)
        {
            driver.FindElement(By.CssSelector(xPath)).Click();
            return this;
        }

        public List<string> AllTabsText => 
            driver.FindElements(_tabsXPath).Select(x => x.Text).ToList();

        public DirectoryOfSpecialistsPageObject NavigateToDirectoryOfSpecialists()
        {
            WaitUntil.WaitForElement(driver, _directoryOfSpecialists);
            driver.FindElement(_directoryOfSpecialists).Click();

            return new DirectoryOfSpecialistsPageObject(driver);
        }

        public MagazinePageObject NavigateToMagazine()
        {
            driver.FindElement(_magazineTab).Click();

            return new MagazinePageObject(driver);
        }
    }
}
