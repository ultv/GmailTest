using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Reflection;
using OpenQA.Selenium.Remote;
//using System.Security.Policy;

namespace GmailTest
{
    [SetUpFixture]
    public class NUnitSetupFixture
    {
        static public IWebDriver browser1;
        static public IWebDriver browser2;
        static public IWebDriver browser3;
        public readonly string url = "http://gmail.com";

        public string login;
        public string pass;
        public PageHome pageHome;
        public PageInbox pageInbox;     
        public ConfigReader conf;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            conf = new ConfigReader();            
            conf.LoadConfig(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.json");
            login = conf.Login;
            pass = conf.Pass;

            //browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            //browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //browser.Manage().Window.Maximize();            
            
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");            
            browser1 = browser1 ?? new RemoteWebDriver(new Uri("http://192.168.1.33:23808/wd/hub"), capabilities);
            browser1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            //browser2 = browser2 ?? new RemoteWebDriver(new Uri("http://192.168.1.33:16602/wd/hub"), capabilities);
            //browser2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
            browser3 = browser3 ?? new RemoteWebDriver(new Uri("http://192.168.1.33:5556/wd/hub"), capabilities);
            browser3.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
//            browser.Quit();
        }
    }

}
