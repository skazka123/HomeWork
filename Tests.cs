using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection_a_name_for_a_pet
{
    public class Tests
    {
        public WebDriverWait wait;
        public ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); //явные ожидания
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //неявные ожидания
        }

        //найти элементы
        private By emailInputLocator = By.Name("email");
        private By sendButtonLocator = By.Id("sendMe");
        private By emailResultTextLocator = By.ClassName("your-email");
        private By anotherEmailLinkLocator = By.LinkText("указать другой e-mail");
        private By boyChoosingAName = By.Id("boy");
        private By girlChoosingAName = By.Id("girl");
        private string ConfirmationOfTheLetterForTheGirl = "Хорошо, мы пришлём имя для вашей девочки на e-mail:";
        private string ConfirmationOfTheLetterForTheBoy = "Хорошо, мы пришлём имя для вашего мальчика на e-mail:";
        private By resultTextAfterSend = By.ClassName("result-text");
        private string errorMessage = "Введите email";
        private  By errorSend = By.ClassName("form-error");

        [Test]
        public void PetNameHomePage_FormWithEmailIsEmpty_Success()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice");
            driver.FindElement(sendButtonLocator).Click();

            Assert.AreEqual(errorMessage, driver.FindElement(errorSend).Text);
        }

        [Test]
        public void PetNameHomePage_FillFormWithEmail_ForBoyEmail_Success()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice");
            driver.FindElement(boyChoosingAName).Click();
            driver.FindElement(emailInputLocator).SendKeys("test@email.ru");
            driver.FindElement(sendButtonLocator).Click();

            Assert.AreEqual("test@email.ru", driver.FindElement(emailResultTextLocator).Text);
        }

        [Test]
        public void PetNameHomePage_FillFormWithEmail_ForBoyText_Success()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice");
            driver.FindElement(boyChoosingAName).Click();
            driver.FindElement(emailInputLocator).SendKeys("test@email.ru");
            driver.FindElement(sendButtonLocator).Click();

            Assert.AreEqual(ConfirmationOfTheLetterForTheBoy, driver.FindElement(resultTextAfterSend).Text);
        }

        [Test]
        public void PetNameHomePage_FillFormWith_ForGirlEmail_Success()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice");
            driver.FindElement(girlChoosingAName).Click();
            driver.FindElement(emailInputLocator).SendKeys("test@email.ru");
            driver.FindElement(sendButtonLocator).Click();

            Assert.AreEqual("test@email.ru", driver.FindElement(emailResultTextLocator).Text);
        }

        [Test]
        public void PetNameHomePage_FillFormWith_ForGirlText_Success()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice");
            driver.FindElement(girlChoosingAName).Click();
            driver.FindElement(emailInputLocator).SendKeys("test@email.ru");
            driver.FindElement(sendButtonLocator).Click();

            Assert.AreEqual(ConfirmationOfTheLetterForTheGirl, driver.FindElement(resultTextAfterSend).Text);
        }

        [Test]
        public void PetNameHomePage_ClickToFillAnotherEmail_EmailInputIsEmpty()
        {
            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice");
            driver.FindElement(emailInputLocator).SendKeys("test@email.ru");
            driver.FindElement(sendButtonLocator).Click();
            driver.FindElement(anotherEmailLinkLocator).Click();

            Assert.AreEqual(string.Empty, driver.FindElement(emailInputLocator).Text);
            Assert.AreEqual(0, driver.FindElements(anotherEmailLinkLocator).Count);
        }


        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }
    }
}
