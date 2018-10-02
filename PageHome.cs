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
        public PageHome(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
        }

        private IWebDriver browser;

        /// <summary>
        /// Поле для ввода имени пользователя.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "whsOnd")]
        private IWebElement LoginInput { get; set; }

        /// <summary>
        /// Приветствие. Появляется после ввода имени пользователя.
        /// </summary>
        [FindsBy(How = How.Id, Using = "headingText")]
        private IWebElement WelcomeText { get; set; }

        /// <summary>
        /// Индикатор профиля. Появляется после ввода имени пользователя.
        /// </summary>
        [FindsBy(How = How.Id, Using = "profileIdentifier")]        
        private By ProfileText { get { return By.Id("profileIdentifier"); } }

        /// <summary>
        /// Открывает главную страницу.
        /// </summary>
        /// <param name="url">Принимает адрес сайта.</param>
        public void Open(string url)
        {
            browser.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Вводит имя пользователя.
        /// </summary>
        /// <param name="login">Принимает имя пользователя.</param>
        /// <returns>Возвращает текст приветствия.</returns>
        public IWebElement EnterLogin(string login)
        {
            LoginInput.Clear();
            LoginInput.SendKeys(login + OpenQA.Selenium.Keys.Enter);            

            return WelcomeText;
        }

        /// <summary>
        /// Вводит пароль.
        /// </summary>
        /// <param name="pass">Принимает пароль.</param>
        /// <returns>Возвращает текст приветствия.</returns>
        public IWebElement EnterPass(string pass)
        {            
            WaitShowElement(browser, ProfileText, 15);

            System.Threading.Thread.Sleep(1000);            
            LoginInput.SendKeys(pass);
            System.Threading.Thread.Sleep(1000);            
            LoginInput.SendKeys(OpenQA.Selenium.Keys.Enter);

            return WelcomeText;
        }

        /// <summary>
        /// Ожидание появления элемента.
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public IWebElement WaitShowElement(IWebDriver browser, By element, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public bool IsVissibleProfileIdentifier()
        {
            List<IWebElement> elements = browser.FindElements(ProfileText).ToList();

            if (elements.Count > 0)
                return true;
            else return false;
        }
    }
}
