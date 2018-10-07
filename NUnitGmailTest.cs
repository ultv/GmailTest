using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;


namespace GmailTest
{

  
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class NUnitGmailTest : Initialization
    {
       
        private IWebDriver browser;

        [Test(Description = "Открытие главной страницы. Chrome.")]
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
            string expected = "Gmail";

            // Act
            string actual = pageHome.Open(BaseUrl);

            // Assert
            Assert.AreEqual(actual, expected);
        }        

        [Test(Description = "Ввод логина. Chrome.")]
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


        [Test(Description = "Вход в профиль. Chrome.")]
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

        [Test(Description = "Ввод пароля. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        public void GmailTest_004()
        {
            // Arrange                       
            pageHome.EnterPass(Pass);

            // Act
            bool actual = pageHome.IsVissibleLoadingInfo();

            // Assert            
            Assert.IsTrue(actual);
        }

        [Test(Description = "Поиск во входящих. Chrome.")]
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

        [Test(Description = "Подсчет и написание. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        public void GmailTest_006()
        {
            // Arrange            
            pageInbox.ResultCount();

            // Act            
            bool actual = pageInbox.WriteMessage(Subject, Message, GetCapabilities());

            // Assert
            Assert.IsTrue(actual);
        }

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            pageInbox.LogOut();
            browser.Quit();
        }
    }
}
