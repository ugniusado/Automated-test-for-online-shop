
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Vcs.Page
{
    class Resize
    {
        protected static IWebDriver Driver;

        public Resize(IWebDriver webdriver)
        {
            Driver = webdriver;
        }
        public void _manageWindowSize()
        {
            Driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
