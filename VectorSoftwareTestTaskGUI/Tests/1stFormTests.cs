using NUnit.Framework;
using VectorSoftwareTestTaskGUI.Pages;
using VectorSoftwareTestTaskGUI.Tools;
using VectorSoftwareTestTaskGUI.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System;

namespace VectorSoftwareTestTaskGUI
{
    [TestFixture]
    [AllureNUnit] 
    //Allure-Reports directory won`t exist on this github repo due to specific symbols in the project`s local directory :)
    [Category("FirstFormTests")]
    public class FirstFormTests: TestRunner
    {
        protected override string HomePageURL { get => "https://tarasmysko89.wixsite.com/vectortesttask01"; }

        User user, invalidEmailUser;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            user = User.CreateBuilder()
                .SetFullName("Sevka Noob")
                .SetEmail("sevka.noob@gmail.com")
                .Build();

            invalidEmailUser = User.CreateBuilder()
                .SetFullName("Sevka Pro")
                .SetEmail("sevka.pro.com")
                .Build();
        }

        [Test]
        [AllureTag("FirstForm")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void SuccessfulSubmitting() //This test doesn`t check message(-s) spelling!
        {
            HomePage homePageDriver = new HomePage(driver);

            homePageDriver.FullNameInput(user.FullName);
            homePageDriver.EmailInput(user.Email);
            homePageDriver.JoinNowClick();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='comp-k5h9ba5e']")));

            string actualSuccessMessage = homePageDriver.SuccessfulSubmittingMessage.Text;

            Assert.That(actualSuccessMessage.Length != 0);
        }

        [Test]
        [AllureTag("FirstForm")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void SubmitButtonTextSpelling()
        {
            string expectedButtonText = "Join Now";

            HomePage homePageDriver = new HomePage(driver);

            string actualButtonText = homePageDriver.SubmitButtonText.Text;

            Assert.AreEqual(expectedButtonText, actualButtonText);
        }

        [Test]
        [AllureTag("FirstForm")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KfN")]
        public void EmailFormat() //This test doesn`t check message(-s) spelling!
        {
            HomePage homePageDriver = new HomePage(driver);

            homePageDriver.FullNameInput(invalidEmailUser.FullName);
            homePageDriver.EmailInput(invalidEmailUser.Email);
            homePageDriver.JoinNowClick();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='comp-k5h9ba5e']")));

            string actualSuccessMessage = homePageDriver.SuccessfulSubmittingMessage.Text;

            Assert.That(actualSuccessMessage.Length == 0);
        }
    }
}