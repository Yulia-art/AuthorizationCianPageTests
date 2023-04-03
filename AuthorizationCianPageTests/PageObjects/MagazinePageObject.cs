using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.PageObjects
{
    class MagazinePageObject
    {
        private IWebDriver driver;

        private readonly By _allNewsTime = By.XPath("//span[@itemprop='datePublished']");

        public MagazinePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IEnumerable<DateTime> GetListNewsTime()
        {
            return driver
                .FindElements(_allNewsTime)
                .Select(x => DateTime.Parse(x.Text));
        }
    }
}
