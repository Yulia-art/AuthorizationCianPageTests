using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests
{
    class UserTestingData
    {
        public static string UserEmail { get; } = "julia.ushnurtseva@gmail.com";
        public static string UserPassword { get; } = "6448Julie";
        public static string UserID { get; } = "ID 100763941";

        public static string RentTab = "a[href='/snyat/']";

        public static string element = "snyat";

        public static By _tabsXPath = By.XPath("//*[@data-name='NavBar']");
    }
}
