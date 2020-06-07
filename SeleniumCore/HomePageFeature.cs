using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace SeleniumCore
{
    [TestClass]
    public class HomePageFeature
    {
        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
    }
}
