using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Tests.PageObjects;
using TechTalk.SpecFlow.Assist;
using Tests.Models;
using System.Linq;

namespace Tests.TestSteps
{
    [Binding]
    public class MainPageSteps
    {
        ScenarioContext _scenarioContext;
        MainPage _mainPage;

        public MainPageSteps(ScenarioContext context)
        {
            _scenarioContext = context;
            _mainPage = new MainPage(_scenarioContext.Get<IWebDriver>("WebDriver"));
        }

        [When(@"item added to the cart")]
        [Then(@"item added to the cart")]
        public void WhenItemAddedToTheCart()
        {
            _mainPage.AddToCart_Btn.Click();
        }

        [Then(@"the item in the cart")]
        public void ThenTheItemInTheCart()
        {
            var itemsCount = _mainPage.ShoppingCart_Bdg.Text;

            Assert.AreEqual("1", itemsCount);

            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }

        [Given(@"we have a table")]
        public void GivenWeHaveATable(Table table)
        {
            var data = table.CreateSet<TestClass>().Single();
        }
    }
}