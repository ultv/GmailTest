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
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureDisplayIgnored]
    class TestClass2
    {
        [Test(Description = "Пример теста Allure")]
        [AllureTag("Regression")]
        //[AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("Седов")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void TestSample2()
        {
           Console.WriteLine(DateTime.Now);
        }
    }


}
