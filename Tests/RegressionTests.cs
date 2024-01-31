using NUnit.Framework;
using System.Threading;
using Tests.PageObjects;

namespace Tests
{
    [TestFixture]
    public class RegressionTests : TestBase
    {
        string _userName = "standard_user";
        string _password = "secret_sauce";

        [Test]
        public void LoginIn()
        {
            //var loginPage = new LoginPage(driverManager.ChromeDriver);
            //loginPage.Login(_userName, _password);
            MainPage mainPage = new MainPage(driverManager.ChromeDriver);
            //mainPage.About_Lnk.Click();

            try
            {
                var alert = driverManager.ChromeDriver.SwitchTo().Alert();
                var a = alert.Text;
                alert.SendKeys("TEST");
                alert.Accept();
            }
            catch
            {

            }


        }

        [Test]
        public void AddItemToTheCart()
        {
            var loginPage = new LoginPage(driverManager.ChromeDriver);

            logger.Info("Step 1: Login to main page");
            var mainPage = loginPage.Login(_userName, _password);

            logger.Info("Step 2: Going to add a bag to the cart");
            mainPage.AddToCart_Btn.Click();

            logger.Info("Step 3: Getting items count number from the cart");
            var itemsCount = mainPage.ShoppingCart_Bdg.Text;

            logger.Info("Step 4: Verifying that bag was added to the cart");
            Assert.AreEqual("1", itemsCount);
        }

        [Test]
        public void ScrollAndDropDown()
        {
            var loginPage = new LoginPage(driverManager.ChromeDriver);
            var mainPage = loginPage.Login(_userName, _password);

            mainPage.AddToCart_Btn.Click();

            mainPage.SelectValueFromDropDown(mainPage.DropDownFilter, "Price (low to high)");

            mainPage.ScrollToElement(driverManager.ChromeDriver, mainPage.FooterText);
        }
    }
}