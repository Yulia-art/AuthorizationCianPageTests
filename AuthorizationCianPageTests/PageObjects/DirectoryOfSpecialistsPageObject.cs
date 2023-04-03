using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.PageObjects
{
    public class DirectoryOfSpecialistsPageObject
    {
        private IWebDriver driver;
        private readonly By _sortByListButton = By.XPath("//div[@data-name='SortFilter']");
        private readonly By _allTheSorts = By.CssSelector("._9400a595a7--item-wrapper"); //By.XPath("//*[@role='option']");

        public DirectoryOfSpecialistsPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public DirectoryOfSpecialistsPageObject SearchSortBy(string nameSort)
        {
            WaitUntil.WaitForElement(driver, _sortByListButton);
            driver.FindElement(_sortByListButton).Click();

            WaitUntil.WaitSomeInterval(2);
            var sortBy = driver.FindElements(_allTheSorts).First(x => x.Text == nameSort); //FirstOrDefault
            sortBy.Click();

            return this;
        }
    }
}
