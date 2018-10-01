using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace GmailTest
{
    public class PageInbox
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
        /// Письма в результатах поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "av")]
        //private IWebElement ResultSearch { get; set; }        
        private By ResultSearch { get { return By.ClassName("av"); } }

        /// <summary>
        /// Кнопка "Написать".
        /// </summary>        
        [FindsBy(How = How.CssSelector, Using = ".T-I-KE")]
        private IWebElement WriteButton { get; set; }

        /// <summary>
        /// Поле ввода адреса получателя.        
        /// </summary>
        [FindsBy(How = How.Name, Using = "to")]
        //[FindsBy(How = How.ClassName, Using = "wA")]
        //[FindsBy(How = How.CssSelector, Using = ".l1 > input:nth-child(1)")]
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
        /// Осуществляет поиск среди входящих писем.
        /// </summary>
        /// <param name="text">Принимает фразу для поиска.</param>
        public void Search(string text)
        {
                WebDriverWait ww = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
                IWebElement input = ww.Until(ExpectedConditions.ElementIsVisible(OptionsBar));

            //System.Threading.Thread.Sleep(7000);
            SearchInput.Clear();
            SearchInput.SendKeys(text + OpenQA.Selenium.Keys.Enter);
        }

        public bool IsVissible()
        {                        
            List<IWebElement> elements = browser.FindElements(OptionsBar).ToList();            

            if (elements.Count > 0)
                return true;
            else return false;
        }

        /// <summary>
        /// Проверяет результаты поиска.
        /// </summary>
        /// <returns>Возвращает количестов найденных писем.</returns>
        public int ResultCount()
        {
            ///???
            WebDriverWait ww = new WebDriverWait(browser, TimeSpan.FromSeconds(15));
            ww.Until(ExpectedConditions.InvisibilityOfElementLocated(OptionsBar));            

            List<IWebElement> elements = browser.FindElements(ResultSearch).ToList();           
            CountMail = elements.Count;

            return CountMail;
        }

        /// <summary>
        /// Заполняет и отправляет сообщение.
        /// </summary>
        public void WriteMessage()
        {
            WriteButton.Click();

            //System.Threading.Thread.Sleep(2000);
            WebDriverWait ww = new WebDriverWait(browser, TimeSpan.FromSeconds(15));            
            IWebElement to = ww.Until(ExpectedConditions.ElementIsVisible(ToInputBy));

            // На firefox без Click() и Clear() не срабатывает!!!
            to.Click();
            to.Clear();
            to.SendKeys("ultv@inbox.ru");
            
            SubjectInput.SendKeys("Тестовое задание. Седов");
            MessageArea.SendKeys($"Количество присланных писем = {CountMail} {OpenQA.Selenium.Keys.Control} {OpenQA.Selenium.Keys.Enter}");            
        }

        
    }
}
