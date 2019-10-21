using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace JiraJWLTest
{
    [Binding]
    public class AppLoginSteps
    {
        IWebDriver webDriver;

        public AppLoginSteps()
        {
            webDriver = new ChromeDriver(@"C:\SeleniumWebDrivers");
        }

        [Given(@"I go to ""(.*)""")]
        public void GivenIGoTo(string url)
        {
            //Go to URL
            webDriver.Navigate().GoToUrl(url);
        }
        
        [Given(@"I click on Log in link")]
        public void GivenIClickOnLogInLink()
        {
            //Navigate to login page
            IWebElement loginLink = webDriver.FindElement(By.Id("loginLink"));
            loginLink.Click();
        }

        [Given(@"I set username with ""(.*)""")]
        public void GivenISetUsernameWith(string email)
        {
            //Capture email input
            IWebElement emailInput = webDriver.FindElement(By.Id("Email"));
            emailInput.SendKeys(email);
        }

        [Given(@"I set password with ""(.*)""")]
        public void GivenISetPasswordWith(string password)
        {
            //Capture password input
            IWebElement passwordInput = webDriver.FindElement(By.Id("Password"));
            passwordInput.SendKeys(password);
        }

        [When(@"I click on login button")]
        public void WhenIClickOnLoginButton()
        {
            //capture login button
            IWebElement loginButton = webDriver.FindElement(By.Id("loginButton"));
            loginButton.Click();
        }

        [Then(@"I should see ""(.*)"" message")]
        public void ThenIShouldSeeMessage(string expectedMessage)
        {
            //Capture login successful message
            IWebElement successfulLoginMessage = webDriver.FindElement(By.XPath("//div[@class='jumbotron']/h1"));
            string actualMessage = successfulLoginMessage.Text;

            //Validate expected message is equal to login successful message
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Then(@"I should see ""(.*)"" error label")]
        public void ThenIShouldSeeErrorLabel(string p0)
        {
            //Capture error message
            IWebElement errorLoginMessage = webDriver.FindElement(By.XPath("//div[@class='validation-summary-errors text-danger']/ul/li"));
            string actualMessage = errorLoginMessage.Text;

            //Validate expected message is equal to error message
            string expectedMessage = "Invalid login attempt.";

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
