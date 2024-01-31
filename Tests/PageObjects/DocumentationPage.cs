using OpenQA.Selenium;

namespace Tests.PageObjects
{
    public class DocumentationPage
    {
        private IWebDriver _driver;

        public IWebElement DocSearch => _driver.FindElement(By.ClassName("DocSearch-Button"));

        public DocumentationPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
