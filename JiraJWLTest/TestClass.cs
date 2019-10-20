using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace JiraJWLTest
{
    [TestClass]
    public class TestClass
    {
        IWebDriver webDriver;

        public TestClass()
        {
            webDriver = new ChromeDriver(@"C:\SeleniumWebDrivers");

            webDriver.Navigate().GoToUrl("http://localhost:49988");
        }

        [TestMethod]
        public void LoginSuccessful()
        {
            //Nvaigate to login page
            IWebElement loginLink = webDriver.FindElement(By.Id("loginLink"));
            loginLink.Click();

            //Capture email input
            IWebElement emailInput = webDriver.FindElement(By.Id("Email"));
            emailInput.SendKeys("merino@live.com");


            //Capture password input
            IWebElement passwordInput = webDriver.FindElement(By.Id("Password"));
            passwordInput.SendKeys("12345");


            //capture login button
            IWebElement loginButton = webDriver.FindElement(By.Id("loginButton"));
            loginButton.Click();

            //Capture login successful message
            IWebElement successfulLoginMessage = webDriver.FindElement(By.XPath("//div[@class='jumbotron']/h1"));
            string actualMessage = successfulLoginMessage.Text;

            //Validate expected message is equal to login successful message
            string expectedMessage = "KUDOS";

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void LoginUnsuccessful()
        {
            //Nvaigate to login page
            IWebElement loginLink = webDriver.FindElement(By.Id("loginLink"));
            loginLink.Click();

            //Capture email input
            IWebElement emailInput = webDriver.FindElement(By.Id("Email"));
            emailInput.SendKeys("merino@live.com");


            //Capture password input
            IWebElement passwordInput = webDriver.FindElement(By.Id("Password"));
            passwordInput.SendKeys("54321");


            //capture login button
            IWebElement loginButton = webDriver.FindElement(By.Id("loginButton"));
            loginButton.Click();

            //Capture login successful message
            IWebElement errorLoginMessage = webDriver.FindElement(By.XPath("//div[@class='validation-summary-errors text-danger']/ul/li"));
            string actualMessage = errorLoginMessage.Text;

            //Validate expected message is equal to login successful message
            string expectedMessage = "Invalid login attempt.";

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
