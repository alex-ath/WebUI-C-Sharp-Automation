using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumCore
{
    [TestClass]
    public class HomePageFeature
    {
        IWebDriver _driver;
        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
            //outPutDirectory helps to dynamically find the ChromeDriver's location
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outPutDirectory);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginButtonLocator = By.ClassName("btn_action");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(loginButtonLocator));

            var userNameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(loginButtonLocator);

            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }
        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
