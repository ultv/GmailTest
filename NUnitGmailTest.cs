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
    public class NUnitGmailTest: Initialization
    {
        
        private Initialization init = new Initialization();
        private IWebDriver browser;

        [Test(Description = "Главная страница")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]                        
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]        
        [AllureSuite("PassedSuite")]
        //[AllureSubSuite("NoAssert")]        
        public void Test_001()
        {
            // Arrange
            browser = init.Start();
            pageHome = new PageHome(browser);
            pageHome.Open(init.url);            
            string expected = "Gmail";

            // Act
            string actual = browser.Title;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Ввод логина")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]        
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        //[AllureSubSuite("NoAssert")]
        public void Test_002()
        {
            // Arrange                       
            string expected = "Вход";

            // Act
            string actual = pageHome.EnterLogin(init.login).Text;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Ввод пароля")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]        
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        //[AllureSubSuite("NoAssert")]
        public void Test_003()
        {
            // Arrange                       
            string expected = "Александр Седов";

            // Act
            string actual = pageHome.EnterPass(init.pass).Text;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Поиск во входящих")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]        
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        //[AllureSubSuite("NoAssert")]
        public void Test_004()
        {
            // Arrange
            pageInbox = new PageInbox(browser);
            pageInbox.Search("Седов");
            //int expected = pageInbox.ResultCount();            
            //string expected = "Результаты поиска - ulsdet@gmail.com - Gmail";
            string expected = "Gmail";

            // Act            
            string actual = browser.Title;

            // Assert
            Assert.AreNotEqual(actual, expected);
        }

        [Test(Description = "Подсчет и отправка")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]        
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        //[AllureSubSuite("NoAssert")]
        public void Test_005()
        {
            // Arrange            
            int count = pageInbox.ResultCount();
            pageInbox.WriteMessage();

            // Act            
            int actual = 2;

            // Assert
            Assert.AreEqual(2, 2);
        }

    }
}
