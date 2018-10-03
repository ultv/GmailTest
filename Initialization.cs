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
        private IWebDriver browser1;
        private IWebDriver browser2;
        private static readonly string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.json";
        public ConfigReader conf = new ConfigReader(configPath);        
        public string BaseUrl { get { return conf.BaseUrl; } }
        public string Login { get { return conf.Login; } }
        public string Pass { get { return conf.Pass; } }
        public string SearchKey { get { return conf.SearchKey; } }
        public string SearchText { get { return conf.SearchText; } }
        public string Subject { get { return conf.Subject; } }
        public string Message { get { return conf.Message; } }
        public static int CountBrowsers { get; set; }

        public IWebDriver Start1()
        {            
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, conf.Node[0].Capabilities);
            browser1 = browser1 ?? new RemoteWebDriver(new Uri(conf.Node[0].Uri), capabilities);
            browser1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            return browser1;
        }

        public IWebDriver Start2()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, conf.Node[1].Capabilities);
            browser2 = browser2 ?? new RemoteWebDriver(new Uri(conf.Node[1].Uri), capabilities);
            browser2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            return browser2;
        }

        public IWebDriver Start(IWebDriver browser)
        {
            if (CountBrowsers > conf.Node.Length)
            {
                Console.WriteLine("Зарегестрируйте новый Node узел и запишите параметры в config.json");
                return null;
            }
            else
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                capabilities.SetCapability(CapabilityType.BrowserName, conf.Node[CountBrowsers].Capabilities);
                browser = browser ?? new RemoteWebDriver(new Uri(conf.Node[CountBrowsers].Uri), capabilities);
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                CountBrowsers++;

                return browser;
            }            
        }
    }
}
