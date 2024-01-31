using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace WebDrv
{
    public class WebDriverUtils
    {
        ITakesScreenshot _takeScreenshot;
        private IWebDriver _driver;

        public WebDriverUtils(IWebDriver driver)
        {
            _driver = driver;
            _takeScreenshot = (ChromeDriver)driver;
        }

        public void TakeScreenshot()
        {
            var screenshotName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            _takeScreenshot.GetScreenshot().SaveAsFile($"D:\\QALightTrainings\\Screenshots\\Test-{screenshotName}.png");
        }

        public void TakeFullWindowScreenshot()
        {
            var screenshotName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker());
            _driver.TakeScreenshot(vcd).ToMagickImage().ToBitmap().Save($"D:\\QALightTrainings\\Screenshots\\Test-{screenshotName}.png");

            
        }
    }
}