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
        
 ## Usage of Class inheritance
 
 ###
 class VarlePage:Resize
    {}
 ###
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
