using Core;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TechTalk.SpecFlow;
using WebDrv;

namespace Tests
{
    public class TestBase
    {
        protected WebDriverUtils driverUtils;
        public WebDriverManager driverManager = new WebDriverManager();
        protected BaseLogger logger = new BaseLogger();
        protected WebDriverWaits waits;
        
        [SetUp]
        public void SetUp()
        {
            logger.Info($"---- Beginning of the {TestExecutionContext.CurrentContext.CurrentTest.Name} test ----");

            //driverManager.ChromeDriver.Navigate().GoToUrl("https://demo.automationtesting.in/Alerts.html");
        }

        [TearDown]
        public void TearDown()
        {
            if(TestExecutionContext.CurrentContext.CurrentResult.FailCount > 0)
            {
                driverUtils.TakeScreenshot();
                logger.Error($"Test {TestExecutionContext.CurrentContext.CurrentTest.Name} has failed with error: {TestExecutionContext.CurrentContext.CurrentResult.Message}.");
            }
            else
            {
                logger.Info($"Test {TestExecutionContext.CurrentContext.CurrentTest.Name} has passsed successfully!");
            }

            logger.Info($"---- Ending of the {TestExecutionContext.CurrentContext.CurrentTest.Name} test ----");
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        { 
            driverUtils = new WebDriverUtils(driverManager.ChromeDriver);
            waits = new WebDriverWaits(driverManager.ChromeDriver);

            logger.Initialize();
            driverManager.ChromeDriver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driverManager.ChromeDriver.Quit();
        }
    }
}
