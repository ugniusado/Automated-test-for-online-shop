using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Vcs.Page;

namespace Vcs.Test
{
    class VarleTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.varle.lt/";

        }


        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }
        [TestCase("Vardenis@Pavardenis.com", "Pavardenis", "Neteisingas el. paštas ir/arba slaptažodis", TestName = "Test Fail Login 1")]
        [TestCase("Vardenis", "Pavar123", "Neteisingas el. paštas ir/arba slaptažodis", TestName = "Test Fail Login 2")]
        [TestCase("*****()...", "....123", "Neteisingas el. paštas ir/arba slaptažodis", TestName = "Test Fail Login 3")]
        public static void TestLogin(string userName, string passWord, string result)
        {
            VarlePage page = new VarlePage(_driver);
            page._manageWindowSize();
            page._clickLoginHeader();
            page._insertTextToUsernameField(userName);
            page._insertTextToPasswordField(passWord);
            page._clickLoginButton();
            page._verifyLoginResult(result);

        }
        [Test]
        public static void TestIsPhoneAvailability()
        {

            VarlePage page = new VarlePage(_driver);
            page._manageWindowSize();
            page._manageWindowSize();
            page._gotoDepartament();
            page._clickOnLinkedText();
            page._inputStartingPrice("1949");
            page._clickLabel();
            page._confirmPhoneName();
        }
        [Test]
        public static void TestBasket()
        {
            VarlePage page = new VarlePage(_driver);
            page._manageWindowSize();
            page._driverGoToPage();
            page._waitUntilElementIsClickable();
            page._orderClick();
            page._checkItemPriceInCart();
            page._clearCart();
        }
    }
}
