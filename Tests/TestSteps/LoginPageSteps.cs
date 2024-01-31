using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Tests.PageObjects;
using WebDrv;

namespace Tests.TestSteps
{
    [Binding]
    public class LoginPageSteps
    {
        ScenarioContext _scenarioContext;
        WebDriverManager _driverManager = new WebDriverManager();

        public LoginPageSteps(ScenarioContext context)
        {
            _scenarioContext = context;
        }

        [Given(@"logged in to the site with username '(.*)' and password '(.*)'")]
        public void GivenLoggedInToTheSiteWithUsernameAndPassword(string userName, string password)
        {
            _driverManager.ChromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var _loginPage = new LoginPage(_driverManager.ChromeDriver);
            _loginPage.Login(userName, password);

            _scenarioContext.Add("WebDriver", _driverManager.ChromeDriver);
        }
    }
}
