using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;


namespace GmailTest
{
    [TestFixture]
    public class NUnitGmailTest : NUnitSetupFixture
    {
        [Test]
        public void Test_001()
        {
            // Arrange           
            pageHome = new PageHome(browser);
            pageHome.Open(url);            
            string expected = "Gmail";

            // Act
            string actual = browser.Title;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Test_002()
        {
            // Arrange                       
            string expected = "Вход";

            // Act
            string actual = pageHome.EnterLogin(conf.Login).Text;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Test_003()
        {
            // Arrange                       
            string expected = "Александр Седов";

            // Act
            string actual = pageHome.EnterPass(conf.Pass).Text;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Test_004()
        {
            // Arrange
            PageInbox inbox = new PageInbox();
            inbox.Search("Седов");

            int expected = inbox.ResultCount();

            //bool expected = true; // проверить!!! ожидаю false

            // Act
            //bool actual = inbox.IsVissible();
            int actual = 2;

            // Assert
            Assert.AreEqual(actual, expected);
        }

    }
}
