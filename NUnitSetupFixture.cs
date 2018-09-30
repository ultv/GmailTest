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
        static public IWebDriver browser { get; set; }        
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
            //capabilities.SetCapability(CapabilityType.BrowserVersion, "69.0.3497.100");
            browser = new RemoteWebDriver(new Uri("http://192.168.1.33:23808/wd/hub"), capabilities);

            //browser = new RemoteWebDriver(new Uri("http://192.168.1.33:16602/wd/hub"), capabilities);


        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
//            browser.Quit();
        }
    }

}
