using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Reflection;

namespace GmailTest
{
    [SetUpFixture]
    public class NUnitSetupFixture
    {
        static public IWebDriver browser;
        public readonly string url = "http://gmail.com";
        public string login;
        public string pass;
        public PageHome pageHome;
        public ConfigReader conf;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            conf = new ConfigReader();
            //conf.LoadConfig("C:\\CODE\\CS\\GmailTest\\bin\\Debug\\config.json");
            conf.LoadConfig(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.json");
            login = conf.Login;
            pass = conf.Pass;

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
