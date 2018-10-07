using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace GmailTest
{
    public class PageInbox : WaitAssistant
    {
        public PageInbox(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
        }

        private IWebDriver browser;

        /// <summary>
        /// Количество найденных писем.
        /// </summary>
        private int CountMail { get; set; }

        /// <summary>
        /// Поле ввода фразы для поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "gb_bf")]
        private IWebElement SearchInput;       

        /// <summary>
        /// Письма с пометкой "входящие" в результатах поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "av")]        
        private By ResultSearch { get { return By.ClassName("av"); } }

        /// <summary>
        /// Кнопка "Написать".
        /// </summary>        
        [FindsBy(How = How.CssSelector, Using = ".T-I-KE")]
        private IWebElement WriteButton;
        private By WriteButtonBy { get { return By.CssSelector(".T-I-KE"); } }

        /// <summary>
        /// Поле ввода адреса получателя.        
        /// </summary>
        [FindsBy(How = How.Name, Using = "to")]
        private IWebElement ToInput;
        private By ToInputBy { get { return By.Name("to"); } }

        /// <summary>
        /// Поле ввода темы письма.
        /// </summary>
        [FindsBy(How = How.Name, Using = "subjectbox")]
        private IWebElement SubjectInput;

        /// <summary>
        /// Поле ввода сообщения.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "Am")]
        private IWebElement MessageArea;
        
        /// <summary>
        /// Кнопка ответить.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "ams")]
        private IWebElement ReplyButton;
        private By ReplyButtonBy { get { return By.ClassName("ams"); } }

        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "oL")]
        private IWebElement MailToText;
        private By MailToTextBy { get { return By.ClassName("oL"); } }

        /// <summary>
        /// Кнопка удалить черновик.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "og")]
        private IWebElement DelReplyButton;
        
        /// <summary>
        /// Иконка "Аккаунт"
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "gb_9a")]
        private IWebElement AccountButton;

        /// <summary>
        /// Ссылка "Выход из аккаунта".
        /// </summary>
        private By ExitLink { get { return By.LinkText("Выйти"); } }

        /// <summary>
        /// Заголовок "Несортированные письма"
        /// </summary>
        private By NonSortedText { get { return By.ClassName("aKz"); } }

        /// <summary>
        /// Сообщение об отправке письма.
        /// </summary>
        private By OkMessage { get { return By.ClassName("bAq"); } }

        /// <summary>
        /// Осуществляет поиск среди входящих писем.
        /// </summary>
        /// <param name="text">Принимает фразу для поиска.</param>
        public bool Search(string text)
        {            
            WaitShowElement(browser, WriteButtonBy, 15);
            SearchInput.Clear();
            SearchInput.SendKeys(text + Keys.Enter);

            return WaitHideElement(browser, NonSortedText, 15);
        }

        /// <summary>
        /// Проверяет результаты поиска.
        /// </summary>
        /// <returns>Возвращает количестов найденных писем.</returns>
        public int ResultCount()
        {
            List<IWebElement> elements = browser.FindElements(ResultSearch).ToList();
            CountMail = elements.Count;

            if (CountMail > 0)
                elements[0].Click();

            return CountMail;
        }

        /// <summary>
        /// Заполняет и отправляет сообщение.
        /// Возвращает true если закрылось окно сообщения и не появилось окно с ошибкой.
        /// </summary>
        public bool WriteMessage(string subject, string message, string capabilities)
        {
            string mailTo = GetMailTo();
            DelReplyButton.Click();

            WriteButton.Click();
            IWebElement sendTo = WaitShowElement(browser, ToInputBy, 15);

            if(capabilities == "firefox")            
                ScriptKeys(mailTo, subject, message + CountMail);
            else
            {            
                sendTo.SendKeys(mailTo);
                SubjectInput.SendKeys(subject);
                MessageArea.SendKeys(message + CountMail);               
            }

            MessageArea.SendKeys(Keys.Control + Keys.Enter);

            if (!WaitReturnException(browser, OkMessage, 10))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получает адрес отпраителя письма.
        /// </summary>
        /// <returns>Отправляет адрес отправителя.</returns>
        public string GetMailTo()
        {
            ReplyButton.Click();
            IWebElement mailTo = WaitShowElement(browser, MailToTextBy, 15);

            return mailTo.Text;
        }

        /// <summary>
        /// Записывает адрес в элемент textarea.
        /// </summary>
        /// <param name="mail"></param>
        public void ScriptKeys(string mail, string sub, string mess)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)browser;            

            js.ExecuteScript("document.getElementsByName('subjectbox')[0].value = '" + sub + "'");
            js.ExecuteScript("document.getElementsByName('to')[0].textContent = '" + mail + "'");

            MessageArea.Click();            
            js.ExecuteScript("document.getElementById(':fy').textContent = '" + mess + "'");
        }

        /// <summary>
        /// Выход из аккаунта.
        /// </summary>
        public void LogOut()
        {
            AccountButton.Click();
            WaitShowElement(browser, ExitLink, 5).Click();
        }

    }
}
