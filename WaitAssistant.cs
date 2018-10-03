using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GmailTest
{
    public class WaitAssistant
    {
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

        /// <summary>
        /// Ожидание сокрытия элемента.
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        public bool WaitHideElement(IWebDriver browser, By element, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
        }
        
        /// <summary>
        /// Определяет видимость элемента.
        /// </summary>
        /// <returns></returns>
        public bool IsVissibleElement(IWebDriver browser, By element)
        {
            List<IWebElement> elements = browser.FindElements(element).ToList();

            if (elements.Count > 0)
                return true;
            else return false;
        }
        
    }
}
