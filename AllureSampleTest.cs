using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;


namespace GmailTest
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    class TestClass
    {
        [Test(Description = "Пример теста Allure")]
        [AllureTag("Regression")]
        //[AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("Седов")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void TestSample()
        {
           Console.WriteLine(DateTime.Now);
        }
    }


}
