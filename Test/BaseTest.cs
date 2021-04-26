using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using VcsWebdriver.Tools;
using Vcs.Page;
using VcsWebdriver.Drivers;

namespace VcsWebdriver.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        private static VarlePage _varlePage;
     

        

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            
            _varlePage = new VarlePage(driver);
            
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }


        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

    }
}