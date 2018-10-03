using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium.Remote;
using System.Reflection;


namespace GmailTest
{

    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class NUnitGmailTest
    {

        private Initialization init = new Initialization();
        private IWebDriver browser;

        [Test(Description = "Открытие главной страницы. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]        
        public void GmailTest_001()
        {
            // Arrange
            browser = init.Start(browser, 1);
            init.pageHome = new PageHome(browser);
            init.pageHome.Open(init.BaseUrl);
            string expected = "Gmail";

            // Act
            string actual = browser.Title;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Ввод логина. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]        
        public void GmailTest_002()
        {
            // Arrange                       
            string expected = "Вход";

            // Act
            string actual = init.pageHome.EnterLogin(init.Login).Text;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Вход в профиль. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]      
        public void GmailTest_003()
        {                     
            // Act         
            bool actual = init.pageHome.IsVissibleProfileIdentifier();

            // Assert
            Assert.IsTrue(actual);
        }

        [Test(Description = "Ввод пароля. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]        
        public void GmailTest_004()
        {
            // Arrange                       
            string expected = $"Добро пожаловать! {init.SearchText}";            

            // Act
            string actual = init.pageHome.EnterPass(init.Pass).Text;

            // Assert            
            StringAssert.Contains(actual, expected);
        }

        [Test(Description = "Поиск во входящих. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]        
        public void GmailTest_005()
        {
            // Arrange
            init.pageInbox = new PageInbox(browser);
            init.pageInbox.Search(init.SearchKey + init.SearchText);            
            string expected = "Gmail";

            // Act            
            string actual = browser.Title;

            // Assert
            Assert.AreNotEqual(actual, expected);
        }

        [Test(Description = "Подсчет и написание. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]        
        public void GmailTest_006()
        {
            // Arrange            
            int count = init.pageInbox.ResultCount();
            init.pageInbox.WriteMessage(init);

            // Act            
            bool actual = init.pageInbox.WaitHideElement(browser, init.pageInbox.GetElementToInput(), 15);            

            // Assert
            Assert.IsTrue(actual);            
        }
        
    }
}
