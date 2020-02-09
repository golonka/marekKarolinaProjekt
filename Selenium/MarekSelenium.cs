using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
namespace TestKM
{
    [TestFixture]
    public class MarekSelenium
    {
        private string url = "https://www.cda.pl/login";

        IWebDriver _driver;
        [SetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void EmptyUsernameAndPassword_ErrorWithTextAccessDenied()
        {
            _driver.Navigate().GoToUrl(url);
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.CssSelector(".content p"))));


            var errorMsg = _driver.FindElement(By.CssSelector(".content p"));

            StringAssert.AreEqualIgnoringCase("Wprowadzone zapytanie jest za krótkie", errorMsg.Text);
        }


        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}