using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using Tests.Models;
using Tests.PageObjects;
using WebDrv;

namespace Tests
{
    [TestFixture]
    public class SmokeTests : TestBase
    {
        string _userName = "standard_user";
        string _password = "secret_sauce";

        [TestCase("standard_user", "secret_sauce")]
        [TestCase("locked_out_user", "secret_sauce")]
        [TestCase("problem_user", "secret_sauce")]
        public void LoginIn(string userName, string password)
        {
            //var loginPage = new LoginPage(driverManager.ChromeDriver);
            //loginPage.Login(userName, password);

           DbHelper.GetAll();

            var employee = new Employee
            {
                Name = "Jack",
                Jobtitle = "QA",
                Level = 2
            };

            DbHelper.Insert(employee);

            ApiHelper.TestPostRequest();

            Thread.Sleep(100000);
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
            var apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

            var loginPage = new LoginPage(driverManager.ChromeDriver);
            
            var mainPage = loginPage.Login(_userName, _password);

            driverUtils.TakeScreenshot();
            driverUtils.TakeFullWindowScreenshot();

            mainPage.ClickAddToCartBtn(waits);

            mainPage.SelectValueFromDropDown(mainPage.DropDownFilter, "Price (low to high)");

            mainPage.ScrollToElement(driverManager.ChromeDriver, mainPage.FooterText);
        }

        [Test]
        public void MultipleWindows()
        {
            var loginPage = new LoginPage(driverManager.ChromeDriver);

            var mainPage = loginPage.Login(_userName, _password);

            mainPage.MurgerMenu.Click();
            mainPage.About_Lnk.Click();
            mainPage.Developers.Click();
            mainPage.Documentation.Click();

            var mainWindowHandle = driverManager.ChromeDriver.CurrentWindowHandle;
            List<string> windowHandles = driverManager.ChromeDriver.WindowHandles.ToList();

            foreach (string handle in windowHandles)
            {
                if (handle != mainWindowHandle)
                {
                    driverManager.ChromeDriver.SwitchTo().Window(handle);
                    break;
                }
            }

            driverManager.ChromeDriver.SwitchTo().Window(mainWindowHandle);

            var doc = new DocumentationPage(driverManager.ChromeDriver);
            doc.DocSearch.SendKeys("test");
        }
    }
}