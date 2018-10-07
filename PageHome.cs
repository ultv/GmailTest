using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace GmailTest
{
    public class PageHome : WaitAssistant
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
        private IWebElement LoginInput;

        /// <summary>
        /// Приветствие. Появляется после ввода имени пользователя.
        /// </summary>
        [FindsBy(How = How.Id, Using = "headingText")]
        private IWebElement WelcomeText;
        private By WelcomeTextBy { get { return By.Id("headingText"); } }

        /// <summary>
        /// Индикатор профиля. Появляется после ввода имени пользователя.
        /// </summary>
        [FindsBy(How = How.Id, Using = "profileIdentifier")]
        private By ProfileText { get { return By.Id("profileIdentifier"); } }

        /// <summary>
        /// Фраза "Забыли пароль?"
        /// </summary>
        private By ForgotPassText { get { return By.CssSelector("#forgotPassword > content > span"); } }

        private By LoadingInfo { get { return By.Id("loading"); } }

        /// <summary>
        /// Кнопка "Перезагрузить"
        /// </summary>
        [FindsBy(How = How.Id, Using = "reload-button")]
        private IWebElement ReloadButton;

        /// <summary>
        /// Открывает главную страницу.
        /// автоматически перегружает, если нет приглашения для входа.
        /// </summary>
        /// <param name="url">Принимает адрес сайта.</param>
        public string Open(string url)
        {
            browser.Navigate().GoToUrl(url);

            while (!WaitShowElementEx(browser, WelcomeTextBy, 1)) 
            {                
                ReloadButton.Click();             
            }

            return browser.Title;
        }
        
        /// <summary>
        /// Вводит имя пользователя.
        /// </summary>
        /// <param name="login">Принимает имя пользователя.</param>
        /// <returns>Возвращает текст приветствия.</returns>
        public IWebElement EnterLogin(string login)
        {
            LoginInput.Clear();
            LoginInput.SendKeys(login + Keys.Enter);            

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

            System.Threading.Thread.Sleep(500);            
            LoginInput.SendKeys(pass);
            System.Threading.Thread.Sleep(500);            
            LoginInput.SendKeys(Keys.Enter);

            return WelcomeText;
        }

        /// <summary>
        /// Определяет видимость элемента "Идентификатор профиля".
        /// </summary>
        /// <returns></returns>
        public bool IsVissibleProfileIdentifier()
        {
            List<IWebElement> elements = browser.FindElements(ProfileText).ToList();

            if (elements.Count > 0)
                return true;
            else return false;
        }

        public bool IsVissibleLoadingInfo()
        {
            return WaitShowElementEx(browser, LoadingInfo, 15);
        }

        /// <summary>
        /// Возвращает текст элемента "Забыли пароль?".
        /// </summary>
        /// <returns></returns>
        public string GetForgotPasswordText()
        {
            return WaitShowElement(browser, ForgotPassText, 15).Text;
        }
    }

    
}
