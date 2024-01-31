using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebDrv;

namespace Tests.PageObjects
{
    public class MainPage : BasePage
    {
        private IWebDriver _driver;

        public IWebElement AddToCart_Btn => _driver.FindElement(By.XPath("//div[@class='inventory_item_description']/div[@class='pricebar']/button"));
        public IWebElement ShoppingCart_Bdg => _driver.FindElement(By.ClassName("shopping_cart_badge"));
        public IWebElement FooterText => _driver.FindElement(By.ClassName("footer_copy"));
        public IWebElement DropDownFilter => _driver.FindElement(By.ClassName("product_sort_container"));
        public IWebElement MurgerMenu => _driver.FindElement(By.Id("react-burger-menu-btn"));
        public IWebElement About_Lnk => _driver.FindElement(By.Id("about_sidebar_link"));
        public IWebElement Developers => _driver.FindElement(By.XPath("//span[text()='Developers']"));
        public IWebElement Documentation => _driver.FindElement(By.XPath("//span[text()='Documentation']"));
        public IWebElement InteractionsWithSimpleElements_Link => _driver.FindElement(By.XPath("//a[text()='Interactions with simple elements']"));
        public IWebElement Male_RadioBtn => _driver.FindElement(By.XPath("//input[@value='male']"));
        public IWebElement Bike_ChkBx => _driver.FindElement(By.XPath("//input[@value='Bike']"));
        public IWebElement ElementInsideIFrame => _driver.FindElement(By.Id("rc-anchor-alert"));
        public IWebElement ShowPromptBox => _driver.FindElement(By.Id("promptexample"));


        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public void ClickAddToCartBtn(WebDriverWaits wait)
        {
            wait.FluentWait(_driver, () => AddToCart_Btn, 10);
            AddToCart_Btn.Click();
        }
    }
}
