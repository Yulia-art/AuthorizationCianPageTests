using AuthorizationCianPageTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.Tests
{
    class CheckElementsSortTests : BaseTests
    {
        [Test]
        public void CheckNewsSort()
        {
            var mainMenuPage = new MainMenuPageObject(driver);

            var magazine = mainMenuPage
                .NavigateToMagazine();

            WaitUntil.ShouldLocate(driver, "/magazine/");

            var actualSortDate = magazine.GetListNewsTime().ToList();

            var expectedSortDate = actualSortDate.OrderByDescending(x => x);

            Assert.IsTrue(expectedSortDate.SequenceEqual(actualSortDate), "WRONG!");
        }
    }
}
