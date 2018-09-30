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
        public PageInbox()
        {
            PageFactory.InitElements(NUnitSetupFixture.browser, this);
        }

        /// <summary>
        /// Количество найденных писем.
        /// </summary>
        private int CountMail { get; set; }

        /// <summary>
        /// Поле ввод фразы для поиска.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "gb_bf")]        
        private By SearchInput { get { return By.ClassName("gb_bf"); } }

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
        [FindsBy(How = How.CssSelector, Using = "#\\3a 5e > div > div")]
        private IWebElement WriteButton { get; set; }

        /// <summary>
        /// Поле ввода адреса получателя.        
        /// </summary>
        [FindsBy(How = How.Name, Using = "to")]
        private IWebElement ToInput { get; set; }

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
        
        /// <summary>
        /// Осуществляет поиск среди входящих писем.
        /// </summary>
        /// <param name="text">Принимает фразу для поиска.</param>
        public void Search(string text)
        {
            WebDriverWait ww = new WebDriverWait(NUnitSetupFixture.browser, TimeSpan.FromSeconds(15));
            IWebElement input = ww.Until(ExpectedConditions.ElementIsVisible(SearchInput));

            input.SendKeys(text + OpenQA.Selenium.Keys.Enter);
        }

        public bool IsVissible()
        {                        
            List<IWebElement> elements = NUnitSetupFixture.browser.FindElements(OptionsBar).ToList();            

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
            WebDriverWait ww = new WebDriverWait(NUnitSetupFixture.browser, TimeSpan.FromSeconds(15));
            ww.Until(ExpectedConditions.InvisibilityOfElementLocated(OptionsBar));            

            List<IWebElement> elements = NUnitSetupFixture.browser.FindElements(ResultSearch).ToList();

            //MessageBox.Show(elements.Count.ToString());

            CountMail = elements.Count;

            return CountMail;
        }

        /// <summary>
        /// Заполняет и отправляет сообщение.
        /// </summary>
        public void WriteMessage()
        {
            WriteButton.Click();
            ToInput.SendKeys("ultv@inbox.ru");
            SubjectInput.SendKeys("Тестовое задание. Седов");
            MessageArea.SendKeys($"Количество присланных писем = {CountMail} {OpenQA.Selenium.Keys.Control} {OpenQA.Selenium.Keys.Enter}");            
        }

        
    }
}
