using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDrv
{
    public class WebDriverWaits
    {
        IWebDriver _driver;

        public WebDriverWaits(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SetImplicitWait(int seconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public void ExplicitWait(IWebDriver driver, Func<IWebElement> element, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => element.Invoke().Displayed);
        }

        public void FluentWait(IWebDriver driver, Func<IWebElement> element, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.PollingInterval = TimeSpan.FromSeconds(1);

            wait.Until(d => element.Invoke().Displayed);
        }
    }
}
