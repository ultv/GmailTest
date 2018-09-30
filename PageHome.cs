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
            PageFactory.InitElements(NUnitSetupFixture.browser, this);
        }

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
            NUnitSetupFixture.browser.Navigate().GoToUrl(url);
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
            WebDriverWait ww = new WebDriverWait(NUnitSetupFixture.browser, TimeSpan.FromSeconds(15));
            IWebElement profile = ww.Until(ExpectedConditions.ElementIsVisible(ProfileText));

            LoginInput.SendKeys(pass);
            LoginInput.SendKeys(OpenQA.Selenium.Keys.Enter);

            return WelcomeText;
        }
    }
}
