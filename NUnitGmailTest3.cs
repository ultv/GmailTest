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
    //[Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class NUnitGmailTest3 : Initialization
    {

        private Initialization init = new Initialization();
        private IWebDriver browser;

        [Test(Description = "Открытие главной страницы. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void GmailTest_001()
        {
            // Arrange            
            browser = init.Start(browser);
            pageHome = new PageHome(browser);
            pageHome.Open(init.BaseUrl);
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
        [AllureSubSuite("NoAssert")]
        public void GmailTest_002()
        {
            // Arrange                       
            string expected = "Вход";

            // Act
            string actual = pageHome.EnterLogin(init.Login).Text;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test(Description = "Вход в профиль. Firefox.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
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
        [AllureSubSuite("NoAssert")]
        public void GmailTest_004()
        {
            // Arrange                       
            string expected = $"Добро пожаловать! {init.SearchText}";

            // Act
            string actual = pageHome.EnterPass(init.Pass).Text;

            // Assert            
            StringAssert.Contains(actual, expected);
        }

        [Test(Description = "Поиск во входящих. Firefox.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void GmailTest_005()
        {
            // Arrange
            pageInbox = new PageInbox(browser);
            pageInbox.Search(init.SearchKey + init.SearchText);
            string expected = "Gmail";

            // Act            
            string actual = browser.Title;

            // Assert
            Assert.AreNotEqual(actual, expected);
        }

        [Test(Description = "Подсчет и отправка. Firefox.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void GmailTest_006()
        {
            // Arrange            
            int count = pageInbox.ResultCount();
            pageInbox.WriteMessage(init);

            // Act            
            bool actual = pageInbox.WaitHideElement(browser, pageInbox.GetElementToInput(), 15);

            // Assert
            Assert.IsTrue(actual);
        }

    }
}
