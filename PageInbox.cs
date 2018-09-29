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
    class PageInbox
    {
        [FindsBy(How = How.ClassName, Using = "gb_bf")]
        private IWebElement SearchInput { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "a35")]
        private IWebElement OptionsBar { get; set; }

        private By ResultSearch { get { return By.ClassName("av"); } }

        [FindsBy(How = How.ClassName, Using = "T-I")]
        private IWebElement WriteButton { get; set; }

        public void Search(string text)
        {
            WebDriverWait ww = new WebDriverWait(NUnitSetupFixture.browser, TimeSpan.FromSeconds(15));
            IWebElement input = ww.Until(ExpectedConditions.ElementIsVisible(By.ClassName("gb_bf")));

            input.SendKeys(text + OpenQA.Selenium.Keys.Enter);
        }

        public bool IsVissible()
        {                        
            List<IWebElement> elements = NUnitSetupFixture.browser.FindElements((By)OptionsBar).ToList();

            //MessageBox.Show(elements.Count.ToString());

            if (elements.Count > 0)
                return true;
            else return false;
        }

        public int ResultCount()
        {
            WebDriverWait ww = new WebDriverWait(NUnitSetupFixture.browser, TimeSpan.FromSeconds(15));
            ww.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("a35")));

            //MessageBox.Show("жди");

            List<IWebElement> elements = NUnitSetupFixture.browser.FindElements(ResultSearch).ToList();

            MessageBox.Show(elements.Count.ToString());

            return elements.Count;
        }

        
    }
}
