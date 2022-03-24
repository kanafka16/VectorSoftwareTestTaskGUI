using NUnit.Framework;
using VectorSoftwareTestTaskGUI.Pages;
using VectorSoftwareTestTaskGUI.Tools;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

using VectorSoftwareTestTaskGUI.Data;

namespace VectorSoftwareTestTaskGUI
{
    [TestFixture]
    public class FirstFormTests: TestRunner
    {
        protected override string HomePageURL { get => "https://tarasmysko89.wixsite.com/vectortesttask01"; }

        User user, invalidEmailUser;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            user = User.CreateBuilder()
                .SetFullName("Seva Noob")
                .SetEmail("seva.noob@gmail.com")
                .Build();

            invalidEmailUser = User.CreateBuilder()
                .SetFullName("Seva Pro")
                .SetEmail("seva.pro.com")
                .Build();
        }

        [Test]
        public void SuccessfulSubmitting() //This test doesn`t check message(-s) spelling!
        {
            HomePage homePageDriver = new HomePage(driver);

            homePageDriver.FullNameInput(user.FullName);
            homePageDriver.EmailInput(user.Email);
            homePageDriver.JoinNowClick();

            string actualSuccessMessage = homePageDriver.SuccessfulSubmittingMessage.Text;

            Assert.That(actualSuccessMessage.Length != 0);
        }

        [Test]
        public void SubmitButtonTextSpelling()
        {
            string expectedButtonText = "Join Now";

            HomePage homePageDriver = new HomePage(driver);

            string actualButtonText = homePageDriver.SubmitButtonText.Text;

            Assert.AreEqual(expectedButtonText, actualButtonText);
        }

        [Test]
        public void EmailFormat() //This test doesn`t check message(-s) spelling!
        {
            HomePage homePageDriver = new HomePage(driver);

            homePageDriver.FullNameInput(invalidEmailUser.FullName);
            homePageDriver.EmailInput(invalidEmailUser.Email);
            homePageDriver.JoinNowClick();

            string actualSuccessMessage = homePageDriver.SuccessfulSubmittingMessage.Text;

            Assert.That(actualSuccessMessage.Length == 0);
        }
    }
}