using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests
{
    public static class WaitUntil
    {
        public static void ShouldLocate (IWebDriver driver, string location) // загрузка url
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions
                    .UrlContains(location));
            }
            catch(WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Cannot find out location: {location}", ex);
            }
        }

        public static void WaitSomeInterval(int seconds = 10)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }

        public static void WaitForElement(IWebDriver driver, By locator, int seconds =  10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions
                .ElementIsVisible(locator));
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions
                .ElementToBeClickable(locator));
        }
    }
}
