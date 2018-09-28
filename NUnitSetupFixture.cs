using OpenQA.Selenium;
using NUnit.Framework;

namespace GmailTest
{
    [SetUpFixture]
    public class NUnitSetupFixture
    {
        static public IWebDriver browser;
        public readonly string url = "http://gmail.com";

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {

        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            browser.Quit();
        }
    }

}
