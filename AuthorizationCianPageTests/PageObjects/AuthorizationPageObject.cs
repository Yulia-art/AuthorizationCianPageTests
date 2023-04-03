using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AuthorizationCianPageTests.PageObjects
{
    class AuthorizationPageObject
    {
        private IWebDriver driver;

        private readonly By _emailField = By.XPath("//input[@name='username']");
        private readonly By _continueButton = By.XPath("//button[@data-name='ContinueAuthBtn']");
        private readonly By _passwordField = By.XPath("//input[@name='password']");
        private readonly By _confirmationCheckbox = By.XPath("//span[contains(@class, 'box')]");
        private readonly By _phoneNumberField = By.XPath("//input[@name='tel']");

        public AuthorizationPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MainMenuPageObject CreateNewUser(string mail, string password, string phoneNumber)
        {
            WaitUntil.WaitForElement(driver, _emailField);
            driver.FindElement(_emailField).SendKeys(mail);
            driver.FindElement(_continueButton).Click();
            driver.FindElement(_confirmationCheckbox).Click();
            driver.FindElement(By.XPath("//*[@data-name='ContinueBtn']")).Click();

            WaitUntil.WaitForElement(driver, _passwordField);
            driver.FindElement(_passwordField).SendKeys(password);
            driver.FindElement(_phoneNumberField).SendKeys(phoneNumber);

            return new MainMenuPageObject(driver);
        }

        public MainMenuPageObject Login(string username, string password)
        {
            driver.FindElement(_emailField).SendKeys(username);
            driver.FindElement(_continueButton).Click();
            WaitUntil.WaitForElement(driver, _passwordField);

            driver.FindElement(_passwordField).SendKeys(password);
            driver.FindElement(_continueButton).Click();

            return new MainMenuPageObject(driver);
        }
    }
}
