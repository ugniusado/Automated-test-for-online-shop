using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }

        public WebDriverWait GetWait(int seconds = 5)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }

    }
}