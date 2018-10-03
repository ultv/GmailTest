﻿using System;
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
    public class NUnitGmailTest2 : Initialization
    {

        private Initialization init = new Initialization();
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
            //browser = init.Start2();
            browser = init.Start(browser, 2);            
            init.pageHome = new PageHome(browser);
            init.pageHome.Open(init.BaseUrl);
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
            init.pageHome.EnterLogin(init.Login);

            // Act
            string actual = init.pageHome.GetForgotPasswordText();

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
            bool actual = init.pageHome.IsVissibleProfileIdentifier();

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
            string expected = $"Добро пожаловать! {init.SearchText}";

            // Act
            string actual = init.pageHome.EnterPass(init.Pass).Text;

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
            init.pageInbox = new PageInbox(browser);
            init.pageInbox.Search(init.SearchKey + init.SearchText);
            string expected = "Gmail";

            // Act            
            bool actual = init.pageInbox.WaitHideElement(browser, init.pageInbox.NonSortedText, 15);

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
            int count = init.pageInbox.ResultCount();
            init.pageInbox.WriteMessage(init);

            // Act            
            bool actual = init.pageInbox.WaitHideElement(browser, init.pageInbox.GetElementToInput(), 15);

            // Assert
            Assert.IsTrue(actual);
        }

    }
}
