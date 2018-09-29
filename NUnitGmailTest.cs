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
        public void TestPageHome()
        {
            // Arrange           
            pageHome = new PageHome(browser);
            pageHome.Open(url);
            pageHome.EnterLogin("12345");
            string expected = "Gmail";

            // Act
            string actual = browser.Title;

            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
