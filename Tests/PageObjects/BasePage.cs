using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Tests.PageObjects
{
    abstract public class BasePage
    {
        public void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click(element).Build().Perform();
        }

        public void SelectValueFromDropDown(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }
    }
}