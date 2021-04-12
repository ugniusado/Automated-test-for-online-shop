using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vcs.Page
{
    class VarlePage:Resize
    {
        private static IWebDriver _driver;
        public VarlePage(IWebDriver webdriver) :base(webdriver)
        {
            _driver = webdriver;
        }
        private IWebElement _loginHeader => _driver.FindElement(By.XPath("//a[@id='login_header']/p"));
        public void _clickLoginHeader()
        {
            _loginHeader.Click();
        }
        private IWebElement _usernameInputField => _driver.FindElement(By.Id("id_username"));
        public void _insertTextToUsernameField(string username)
        {
            _usernameInputField.Clear();
            _usernameInputField.SendKeys(username);
        }
        private IWebElement _passwordInputField => _driver.FindElement(By.Id("id_password"));
        public void _insertTextToPasswordField(string password)
        {
            _passwordInputField.Clear();
            _passwordInputField.SendKeys(password);
        }
        private IWebElement _loginButton => _driver.FindElement(By.Name("login"));
        public void _clickLoginButton()
        {
            _loginButton.Click();
        }
        private IWebElement _loginResult => _driver.FindElement(By.XPath("xpath=//form/ul/li"));
        public void _verifyLoginResult(string result)
        {
            int it = 0;
            if (it == 0)
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(_driver => _driver.FindElement(By.Id("c-right")).Displayed);
                IWebElement but = _driver.FindElement(By.Id("c-right"));
                but.Click();
                it++;
            }
            _driver.FindElement(By.CssSelector(".errorlist > li")).Click();
            Assert.That(_driver.FindElement(By.CssSelector(".errorlist > li")).Text, Is.EqualTo(result));
        }
      
        private IWebElement _findDepartament1 => _driver.FindElement(By.CssSelector(".departments-links > .departments-item:nth-child(1) span"));
        public void _gotoDepartament()
        {
            _findDepartament1.Click();
        }
        private IWebElement _findDepartament2 => _driver.FindElement(By.LinkText("Mobilieji telefonai"));
        public void _clickOnLinkedText()
        {
            _findDepartament2.Click();
        }
        private IWebElement _priceInputBox => _driver.FindElement(By.Id("amount-from"));
        public void _inputStartingPrice(string stPrice)
        {
            _priceInputBox.SendKeys(stPrice);
            _priceInputBox.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }
        private IWebElement _findLabel => _driver.FindElement(By.CssSelector(".filters_v2-section:nth-child(2) .filters_v2-filter:nth-child(2) .has-search > .filters_v2-facet:nth-child(1) label"));
        public void _clickLabel()
        {
            _findLabel.Click();
            Thread.Sleep(2000);
        }
        private IWebElement _phoneName => _driver.FindElement(By.CssSelector(".inner > span"));
        public void _confirmPhoneName()
        {
            Assert.That(_phoneName.Text.Contains("Išmanusis telefonas RAZR+ 8/256GB Mercury Sidabrinis"));
        }
        public void _driverGoToPage()
        {
            _driver.Navigate().GoToUrl("https://www.varle.lt/nesiojami-kompiuteriai/nesiojami-kompiuteriai/");
        }
        public void _waitUntilElementIsClickable()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement a = _driver.FindElement(By.CssSelector("#order-button-14245023 > img"));
            wait.Until(ExpectedConditions.ElementToBeClickable(a));
        }
        public void _orderClick()
        {
            _driver.FindElement(By.CssSelector("#order-button-14245023 > img")).Click();
        }
        public void _checkItemPriceInCart()
        {
            Assert.That(_driver.FindElement(By.CssSelector(".price > strong")).Text, Is.EqualTo("899 €"));
        }
        public void _clearCart()
        {
            _driver.FindElement(By.CssSelector(".remove")).Click();
        }







    }
}
