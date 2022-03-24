using OpenQA.Selenium;
using VectorSoftwareTestTaskGUI.Tools;

namespace VectorSoftwareTestTaskGUI.Pages
{
    public class HomePage : TestRunner
    {
        protected override string HomePageURL { get => "https://tarasmysko89.wixsite.com/vectortesttask01"; }

        public IWebElement FullNameField 
        { 
            get 
            { 
                return driver.FindElement(By.XPath("//input[@id='input_comp-jxd8gccb']")); 
            } 
        }

        public IWebElement EmailField 
        { 
            get 
            { 
                return driver.FindElement(By.XPath("//input[@id='input_comp-k5hb1d85']")); 
            } 
        }

        public IWebElement SuccessfulSubmittingMessage 
        { 
            get 
            { 
                return driver.FindElement(By.XPath("//div[@id='comp-k5h9ba5e']")); 
            } 
        }

        public IWebElement SubmitButtonText
        {
            get
            {
                return driver.FindElement(By.CssSelector("div[id='comp-jxd8gccw'] span[class='_1Qjd7']"));
            }
        }

        public IWebElement JoinNowButton { get { return driver.FindElement(By.XPath("//div[@id='comp-jxd8gccw']//button[@class='_1fbEI']")); } }

        public HomePage(IWebDriver driver) 
        { 
            this.driver = driver; 
        }

        public void FullNameInput(string fullName)
        {
            FullNameField.Click();
            FullNameField.SendKeys(fullName);
        }

        public void EmailInput(string fullName)
        {
            EmailField.Click();
            EmailField.SendKeys(fullName);
        }

        public void JoinNowClick()
        {
            JoinNowButton.Click();
        }
    }
}
