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

        /*
         * При частом использовании требует ввод капчи.
         * 
        [Test(Description = "Ввод логина. Негативный сценарий. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        public void GmailTest_002()
        {
            // Arrange                                   
            string expected = "Введите адрес электронной почты или номер телефона";
            pageHome.EnterLogin("Неверный логин");            

            // Act
            string actual = pageHome.GetErrorLoginPassMessage();

            // Assert
           Assert.AreEqual(actual, expected);
        }
        */

        [Test(Description = "Ввод логина. Вход в профиль. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]      
        public void GmailTest_003()
        {
            pageHome.EnterLogin(Login);

            // Act         
            bool actual = pageHome.IsVissibleProfileIdentifier();

            // Assert
            Assert.IsTrue(actual);
        }

        /*
         * При частом использовании требует ввод капчи.
         *
        [Test(Description = "Ввод пароля. Негативный сценарий. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        public void GmailTest_004()
        {
            // Arrange                       
            pageHome.EnterPass("Неверный пароль");
            string expected = "Неверный пароль. Повторите попытку или нажмите на ссылку \"Забыли пароль?\", чтобы сбросить его.";

            // Act
            string actual = pageHome.GetErrorLoginPassMessage();

            // Assert            
            Assert.AreEqual(actual, expected);
        }
        */

        [Test(Description = "Ввод пароля. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        public void GmailTest_005()
        {
            // Arrange                       
            pageHome.EnterPass(Pass);

            // Act
            bool actual = pageHome.IsExistLoadingInfo();

            // Assert            
            Assert.IsTrue(actual);
        }

        [Test(Description = "Поиск во входящих. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        public void GmailTest_006()
        {
            // Arrange
            pageInbox = new PageInbox(browser);            

            // Act            
            bool actual = pageInbox.Search(SearchKey + SearchText);

            // Assert
            Assert.IsTrue(actual);
        }                

        [Test(Description = "Отправка сообщения. Chrome.")]
        [AllureTag("NUnit", "Regression")]
        [AllureOwner("Седов А")]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureSuite("PassedSuite")]
        public void GmailTest_007()
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
