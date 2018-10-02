using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GmailTest
{
    public class Initialization
    {               
        public PageHome pageHome;
        public PageInbox pageInbox;
        private IWebDriver browser;
        private static readonly string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.json";
        public ConfigReader conf = new ConfigReader(configPath);        
        public string BaseUrl { get { return conf.BaseUrl; } }
        public string Login { get { return conf.Login; } }
        public string Pass { get { return conf.Pass; } }
        public string SearchText { get { return conf.SearchText; } }        

        public IWebDriver Start()
        {            
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            browser = browser ?? new RemoteWebDriver(new Uri(conf.Uri[0]), capabilities);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            return browser;
        }        
    }
}
