using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace VectorSoftwareTestTaskGUI.Tools
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        protected abstract string HomePageURL { get; }

        [SetUp]
        public void BeforeEachMethod()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-blink-features=AutomationControlled");

            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(HomePageURL);
        }
    }
}
