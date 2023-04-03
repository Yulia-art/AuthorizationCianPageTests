using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.Tests
{
    class CheckingOperationsOfLocatorsTests : BaseTests
    {
        private readonly By _idLocator = By.Id("header-frontend");
        private readonly By _nameLocator = By.Name("search_query");
        private readonly By _linkText = By.LinkText("Войти");
        private readonly By _partText = By.PartialLinkText("Разместить ");
        private readonly By _tagName = By.TagName("body");
        private readonly By _className = By.ClassName("mainpage");

        [Test]
        public void CheckLocatorById()
        {
            driver.FindElement(_idLocator).Click();
        }

        [Test]
        public void CheckLocatorByName()
        {
            driver.FindElement(_nameLocator).Click();
        }

        [Test]
        public void CheckLocatorLinkText()
        {
            driver.FindElement(_linkText).Click();
        }

        [Test]
        public void CheckLocatorPartLinkText()
        {
            driver.FindElement(_partText).Click();
        }

        [Test]
        public void CheckLocatorTagName()
        {
            driver.FindElement(_tagName);
        }

        [Test]
        public void CheckLocatorClassName()
        {
            driver.FindElement(_className).Click();
        }
    }
}
