using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace VcsWebdriver.Drivers
{
    public class CustomDriver
    {

        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browsers.Chrome);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            return GetDriver(Browsers.Firefox);
        }

        public static IWebDriver GetIncognitoChrome()
        {
            return GetDriver(Browsers.IncognitoChrome);
        }

        private static IWebDriver GetDriver(Browsers browserName)
        {
            IWebDriver webdriver = null;

            switch (browserName)
            {
                case Browsers.Chrome:
                    webdriver = new ChromeDriver();
                    break;
                case Browsers.Firefox:
                    webdriver = new FirefoxDriver();
                    break;
                case Browsers.Opera:
                    webdriver = new OperaDriver();
                    break;
                case Browsers.IncognitoChrome:
                    webdriver = getChromeWithIncognitoOption();
                    break;
                default:
                    webdriver = new OperaDriver();
                    break;
            }
            webdriver.Manage().Window.Maximize();
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return webdriver;
        }

        private static IWebDriver getChromeWithIncognitoOption()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");

            //options.AddArguments("incognito", "start-maximized");
            return new ChromeDriver(options);

        }
    }
}