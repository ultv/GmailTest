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
        /// Поле ввод фразы для поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "gb_bf")]        
        private IWebElement SearchInput { get; set; }

        /// <summary>
        /// Панель опций.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "a35")]        
        private By OptionsBar { get { return By.ClassName("a35"); } }

        /// <summary>
        /// Письма с пометкой "входящие" в результатах поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "av")]
        //private IWebElement ResultSearch { get; set; }        
        private By ResultSearch { get { return By.ClassName("av"); } }

        /// <summary>
        /// Кнопка "Написать".
        /// </summary>        
        [FindsBy(How = How.CssSelector, Using = ".T-I-KE")]
        private IWebElement WriteButton { get; set; }
        private By WriteButtonBy { get { return By.CssSelector(".T-I-KE"); } }

        /// <summary>
        /// Поле ввода адреса получателя.        
        /// </summary>
        [FindsBy(How = How.Name, Using = "to")]        
        private IWebElement ToInput { get; set; }
        private By ToInputBy { get { return By.Name("to"); } }

        /// <summary>
        /// Поле ввода темы письма.
        /// </summary>
        [FindsBy(How = How.Name, Using = "subjectbox")]
        private IWebElement SubjectInput { get; set; }

        /// <summary>
        /// Поле ввода сообщения.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "Am")]
        private IWebElement MessageArea { get; set; }

        [FindsBy(How = How.CssSelector, Using = "img.gb_Wa")]
        private By LogoImage { get { return By.ClassName("img.gb_Wa"); } }

        /// <summary>
        /// Кнопка ответить.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "ams")]
        private IWebElement ReplyButton { get; set; }
        private By ReplyButtonBy { get { return By.ClassName("ams"); } }

        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "oL")]
        private IWebElement MailToText { get; set; }
        private By MailToTextBy { get { return By.ClassName("oL"); } }

        /// <summary>
        /// Кнопка удалить черновик.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "og")]
        private IWebElement DelReplyButton { get; set; }       

        /// <summary>
        /// Заголовок "Несортированные письма"
        /// </summary>
        private By NonSortedText { get { return By.ClassName("aKz"); } }

        /// <summary>
        /// Осуществляет поиск среди входящих писем.
        /// </summary>
        /// <param name="text">Принимает фразу для поиска.</param>
        public bool Search(string text)
        {           
            WaitShowElement(browser, OptionsBar, 15);            
            SearchInput.Clear();
            SearchInput.SendKeys(text + OpenQA.Selenium.Keys.Enter);

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
        /// </summary>
        public bool WriteMessage(string subject, string message)
        {          
            string mailTo = GetMailTo();
            
            DelReplyButton.Click();
            WriteButton.Click();
            IWebElement sendTo = WaitShowElement(browser, ToInputBy, 15);

            // На firefox без Click() и Clear() не срабатывает!!!            
            sendTo.Click();
            sendTo.Clear();
            sendTo.SendKeys(mailTo);            

            SubjectInput.SendKeys(subject);            
            MessageArea.SendKeys(message + CountMail);            
            MessageArea.SendKeys(OpenQA.Selenium.Keys.Control + OpenQA.Selenium.Keys.Enter);

            return WaitHideElement(browser, ToInputBy, 15);
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

        
    }
}
