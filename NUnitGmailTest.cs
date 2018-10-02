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
    public class NUnitGmailTest : Initialization
    {

        private Initialization init = new Initialization();
        private IWebDriver browser;

        [Test(Description = "Открытие главной страницы. Chrome.")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void Test_001()
        {
            // Arrange
            browser = init.Start1();
            pageHome = new PageHome(browser);
            pageHome.Open(init.BaseUrl);
            string expected = "Gmail";

            // Act
            string actual = browser.Title;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Ввод логина. Chrome.")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void Test_002()
        {
            // Arrange                       
            string expected = "Вход";

            // Act
            string actual = pageHome.EnterLogin(init.Login).Text;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Вход в профиль. Chrome.")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void Test_003()
        {                     
            // Act         
            bool actual = pageHome.IsVissibleProfileIdentifier();

            // Assert
            Assert.IsTrue(actual);
        }

        [Test(Description = "Ввод пароля. Chrome.")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void Test_004()
        {
            // Arrange                       
            string expected = "Александр Седов";            

            // Act
            string actual = pageHome.EnterPass(init.Pass).Text;

            // Assert
            Assert.AreEqual(actual, expected);            
        }

        [Test(Description = "Поиск во входящих. Chrome.")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void Test_005()
        {
            // Arrange
            pageInbox = new PageInbox(browser);
            pageInbox.Search(init.SearchText);            
            string expected = "Gmail";

            // Act            
            string actual = browser.Title;

            // Assert
            Assert.AreNotEqual(actual, expected);
        }

        [Test(Description = "Подсчет и отправка. Chrome.")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void Test_006()
        {
            // Arrange            
            int count = pageInbox.ResultCount();
            pageInbox.WriteMessage();

            // Act            
            bool actual = pageInbox.WaitHideElement(browser, pageInbox.GetElementToInput(), 15);

            // Assert
            Assert.IsTrue(actual);
        }

    }
}
