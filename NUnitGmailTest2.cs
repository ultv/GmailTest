﻿using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;


namespace GmailTest
{

    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class NUnitGmailTest2 : Initialization
    {

        //private Initialization init = new Initialization();
        private IWebDriver browser;

        [Test(Description = "Открытие главной страницы. Firefox.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]       
        public void GmailTest_001()
        {
            // Arrange            
            browser = Start(browser);            
            pageHome = new PageHome(browser);
            pageHome.Open(BaseUrl);
            string expected = "Gmail";

            // Act
            string actual = browser.Title;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Ввод логина. Firefox.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        public void GmailTest_002()
        {
            // Arrange                       
            string expected = "Забыли пароль?";
            pageHome.EnterLogin(Login);

            // Act
            string actual = pageHome.GetForgotPasswordText();

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Вход в профиль. Firefox.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]        
        public void GmailTest_003()
        {
            // Act         
            bool actual = pageHome.IsVissibleProfileIdentifier();

            // Assert
            Assert.IsTrue(actual);
        }

        [Test(Description = "Ввод пароля. Firefox.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]       
        public void GmailTest_004()
        {
            // Arrange                       
            string expected = $"Добро пожаловать! {SearchText}";

            // Act
            string actual = pageHome.EnterPass(Pass).Text;

            // Assert            
            StringAssert.Contains(actual, expected);
        }

        [Test(Description = "Поиск во входящих. Firefox.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]     
        public void GmailTest_005()
        {
            // Arrange
            pageInbox = new PageInbox(browser);            

            // Act            
            bool actual = pageInbox.Search(SearchKey + SearchText);

            // Assert
            Assert.IsTrue(actual);
        }

        [Test(Description = "Подсчет и написание. Firefox.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]        
        public void GmailTest_006()
        {
            // Arrange            
            int count = pageInbox.ResultCount();            

            // Act            
            bool actual = pageInbox.WriteMessage(Subject, Message);

            // Assert
            Assert.IsTrue(actual);
        }

    }
}