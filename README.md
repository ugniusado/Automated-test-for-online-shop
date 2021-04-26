# TestVarle
Automatic Test of the site www.varle.lt

## Implemented ideas and code functionality
• *the code has a minimum of 5 meaningful tests, each test has a minimum of 3 steps*

• *the code goes through the pages of 5 different sites*

• *Code is written in Page Object Pattern*

• *There are so-called base classes inheritance*

• *Usage of SetUp / TearDown*

• *Usage of Explicit Wait*

## Usage of SetUp/TearDown
### [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.varle.lt/";
        }


 ###  [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }
   
 ### [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }
        
 ## Usage of Class inheritance
 
 ### Inheriting Class
        class VarlePage:Resize
        {}
 ### Base Class
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
