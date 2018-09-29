using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GmailTest
{
    public class PageHome
    {
        private IWebDriver browser;

        [FindsBy(How = How.ClassName, Using = "whsOnd")]
        private IWebElement LoginInput { get; set; }

        public PageHome(IWebDriver browser)
        {
            this.browser = browser;            
            PageFactory.InitElements(browser, this);
        }

        public void Open(string url)
        {
            browser.Navigate().GoToUrl(url);
        }

        public void EnterLogin(string login)
        {
            LoginInput.Clear();
            LoginInput.SendKeys(login);
        }
    }
}
