using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using System.Reflection;
using OpenQA.Selenium;


namespace GmailTest
{
    public class Initialization
    {
        public readonly string url = "http://gmail.com";

        public string login;
        public string pass;
        public string[] uri;
        public PageHome pageHome;
        public PageInbox pageInbox;
        public ConfigReader conf = new ConfigReader();
        IWebDriver browser;

        public IWebDriver Start()
        {
            conf.LoadConfig(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.json");
            login = conf.Login;
            pass = conf.Pass;
            uri = conf.Uri;

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            browser = browser ?? new RemoteWebDriver(new Uri(conf.Uri[0]), capabilities);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            return browser;
        }

    }
}
