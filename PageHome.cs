using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;

namespace GmailTest
{
    public class PageHome
    {
        //       private IWebDriver browser;

        public PageHome(IWebDriver browser)
        {
            //NUnitSetupFixture.browser = browser;
            PageFactory.InitElements(NUnitSetupFixture.browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "whsOnd")]
        private IWebElement LoginInput { get; set; }

        [FindsBy(How = How.Id, Using = "headingText")]
        private IWebElement WelcomeText { get; set; }
        
        private By ProfileText { get { return By.Id("profileIdentifier"); } }       

        public void Open(string url)
        {
            NUnitSetupFixture.browser.Navigate().GoToUrl(url);
        }

        public IWebElement EnterLogin(string login)
        {
            LoginInput.Clear();
            LoginInput.SendKeys(login + OpenQA.Selenium.Keys.Enter);            

            return WelcomeText;
        }

        public IWebElement EnterPass(string pass)
        {
            WebDriverWait ww = new WebDriverWait(NUnitSetupFixture.browser, TimeSpan.FromSeconds(15));
            IWebElement profile = ww.Until(ExpectedConditions.ElementIsVisible(ProfileText));

            LoginInput.SendKeys(pass + OpenQA.Selenium.Keys.Enter);            

            return WelcomeText;
        }
    }
}
