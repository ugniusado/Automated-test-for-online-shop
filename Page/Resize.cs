
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public void _CloseBrowser()
        {
            Driver.Quit();
        }
        public static void _screenShot()
        {
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Temp\Download\Image.png",
            ScreenshotImageFormat.Png);
        }
    }
}
