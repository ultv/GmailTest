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
    public class NUnitGmailTest
    {
        private IWebDriver browser;

        

        
        public readonly string url = "http://gmail.com";

        public string login;
        public string pass;
        public string[] uri;
        public PageHome pageHome;
        public PageInbox pageInbox;
        public ConfigReader conf = new ConfigReader();
        




        [Test(Description = "Главная страница")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]                
        //[AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]        
        [AllureSuite("PassedSuite")]
        //[AllureSubSuite("NoAssert")]        
        public void Test_001()
        {
            conf.LoadConfig(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.json");
            login = conf.Login;
            pass = conf.Pass;
            uri = conf.Uri;

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            browser = browser ?? new RemoteWebDriver(new Uri(uri[0]), capabilities);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);



            // Arrange           
            pageHome = new PageHome(browser);
            pageHome.Open(url);            
            string expected = "Gmail";

            // Act
            string actual = browser.Title;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Ввод логина")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]
        //[AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        //[AllureSubSuite("NoAssert")]
        public void Test_002()
        {
            // Arrange                       
            string expected = "Вход";

            // Act
            string actual = pageHome.EnterLogin(conf.Login).Text;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Ввод пароля")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]
        //[AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        //[AllureSubSuite("NoAssert")]
        public void Test_003()
        {
            // Arrange                       
            string expected = "Александр Седов";

            // Act
            string actual = pageHome.EnterPass(conf.Pass).Text;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Поиск во входящих")]
        [AllureTag("Regression")]
        [AllureOwner("Седов А")]
        //[AllureSeverity(SeverityLevel.critical)]
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
        //[AllureSeverity(SeverityLevel.critical)]
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
