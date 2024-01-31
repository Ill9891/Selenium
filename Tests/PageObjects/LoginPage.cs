using OpenQA.Selenium;

namespace Tests.PageObjects
{
    public class LoginPage : BasePage
    {
        private IWebDriver _driver;

        public IWebElement UserName_Field => _driver.FindElement(By.Id("user-name"));
        public IWebElement Password_Field => _driver.FindElement(By.Id("password"));
        public IWebElement LogIn_Btn => _driver.FindElement(By.Id("login-button"));
        public IWebElement ShoppingCart_Bdg => _driver.FindElement(By.ClassName("shopping_cart_badge"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public MainPage Login(string userName, string password)
        {
            UserName_Field.SendKeys(userName);
            Password_Field.SendKeys(password);
            LogIn_Btn.Click();

            return new MainPage(_driver);
        }
    }
}