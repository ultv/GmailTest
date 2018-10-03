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
using System.Threading;

namespace GmailTest
{
    /// <summary>
    /// Реализует безопасный многопоточный счётчик.
    /// </summary>
    public class MultiThreadingCounter
    {
        private int number;

        public MultiThreadingCounter()
        {
            int startValue = -1; //т.к. первое возвращённое значение должно быть равно нулевому индексу массива;
            Interlocked.Exchange(ref number, startValue);
        }

        public int Next()
        {
            return (int)Interlocked.Increment(ref number);
        }
    }

    /// <summary>
    /// Запускает отдельный драйвер для каждого запущенного теста.
    /// Параметры для запуска передаются через CohfigReader из config.json файла.
    /// Для каждого запускаемого класса тестов необходим работающий Node узел SeleniumGrid
    /// и параметры узла указанные в config.json файле.
    /// </summary>
    public class Initialization
    {               
        public PageHome pageHome;
        public PageInbox pageInbox;       
        private static readonly string configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.json";
        public ConfigReader conf;        
        public string BaseUrl { get { return conf.BaseUrl; } }
        public string Login { get { return conf.Login; } }
        public string Pass { get { return conf.Pass; } }
        public string SearchKey { get { return conf.SearchKey; } }
        public string SearchText { get { return conf.SearchText; } }
        public string Subject { get { return conf.Subject; } }
        public string Message { get { return conf.Message; } }
        //public static MultiThreadingCounter CountBrowsers;
        
        public Initialization()
        {
            conf = new ConfigReader(configPath);
            //MultiThreadingCounter CountBrowsers = new MultiThreadingCounter();
        }

        public IWebDriver Start(IWebDriver browser, int numTest)
        {
            //int count = CountBrowsers.Next();
            numTest--;

            if ( numTest < conf.Node.Length)
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();            
                capabilities.SetCapability(CapabilityType.BrowserName, conf.Node[numTest].Capabilities);
                browser = browser ?? new RemoteWebDriver(new Uri(conf.Node[numTest].Uri), capabilities);
                browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                                               
                return browser;
            }
            else
            {                
                Console.WriteLine("Запустите новый SeleniumGrid Node узел и запишите параметры в config.json");
                return null;
            }            
        }
    }
}
