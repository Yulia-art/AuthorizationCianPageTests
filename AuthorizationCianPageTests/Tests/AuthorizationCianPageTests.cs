using AuthorizationCianPageTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorizationCianPageTests.Tests
{
    [TestFixture]
    public class AuthorizationCianPageTests : BaseTests
    {
        private const int _mailNameSize = 10;
        private const int _passwordSize = 15;


        private readonly By _magazineList = By.XPath("//*[@id='main-nav']");

        [Test]
        public void Test1()
        {
            var mainMenuPage = new MainMenuPageObject(driver);

            Assert.IsTrue(mainMenuPage.CheckElementPresent_FirstWay(UserTestingData.RentTab));
            Assert.IsTrue(mainMenuPage.CheckElementPresent_SecondWay(UserTestingData.element));

            //Assert.Throws<NoSuchElementException>(() => mainMenuPage.NavigateToTab(UserTestingData.RentTab));

            //Assert.That(mainMenuPage.AllTabsText, Has.No.Member(MainMenuTabs.BuyTab));

            mainMenuPage
                .SignIn()
                .Login(UserTestingData.UserEmail, UserTestingData.UserPassword);

            string actualLogin = mainMenuPage.GetUserLogin();

            Assert.That(actualLogin, Is.EqualTo(UserTestingData.UserID), "Login is wrong or Enter wasn't completed");
        }

        [Test]
        public void SignInAsNewUser()
        {
            var mainMenuPage = new MainMenuPageObject(driver);

            mainMenuPage
                .SignIn()
                .CreateNewUser(TestGenerateData.GenerateRandomEmail(NameDomen.GMail), TestGenerateData.GenerateRandomPassword(_passwordSize), 
                TestGenerateData.GenerateRandomPhoneNumber(CountryCode.Russia, LenghtOfThePhoneNumber.Russia));
        }

        [Test]
        public void LoginAsUser_SerializeData()
        {
            EnviromentConstantWriter enviromentConstantWriter = new EnviromentConstantWriter();
            enviromentConstantWriter.WriteDown();
        }

        [Test]
        public void LoginAsUser_DeserializeData()
        {
            Console.WriteLine(enviromentConstants.Name);
        }

        [Test]
        public void SearchList()
        {
            var mainMenuPage = new MainMenuPageObject(driver);

            mainMenuPage
                .NavigateToDirectoryOfSpecialists()
                .SearchSortBy(NameSort.ByNumberOfAdsSort);
        }

        [Test]
        public void CheckMagazineDownloadingTime()
        {
            var mainMenuPage = new MainMenuPageObject(driver);

            var timeBefore = DateTime.Now;

            mainMenuPage
                .NavigateToMagazine();

            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(_magazineList));

            var timeAfter = DateTime.Now;

            var loadTime = timeAfter - timeBefore;

            Assert.IsTrue(loadTime.Seconds < 2, loadTime.ToString());
        }
    }
}