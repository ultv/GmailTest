using OpenQA.Selenium;
using NUnit.Framework;
using System;

namespace GmailTest
{
    [SetUpFixture]
    public class NUnitSetupFixture
    {
        static public IWebDriver browser;
        public readonly string url = "http://gmail.com";
        public PageHome pageHome;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            browser.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            browser.Quit();
        }
    }

}
