using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{

    [TestClass]
    public class UnitTest1_Login
    {

        private string baseURL = "localhost:62008/Login.aspx";
        private RemoteWebDriver driver = new ChromeDriver();
        public TestContext TestContext { get; set; }



        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(1)]
        [Owner("Chrome")]

        public void TestMethod1()
        {

            //Try to login with an invalid user

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            driver.Navigate().GoToUrl(baseURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Find username form
            IWebElement username = driver.FindElementById("TextBoxUsername");
            username.Clear();
            username.SendKeys("asdf@123.com");
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id("TextBoxUsername"), "asdf@123.com"));

            //Find password form
            IWebElement password = driver.FindElementById("TextBoxPassword");
            password.Clear();
            password.SendKeys("blahblah");
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id("TextBoxPassword"), "blahblah"));

            IWebElement login_button = driver.FindElementById("ButtonLogin");
            login_button.Click();

            //wait.Until(ExpectedConditions.AlertIsPresent());
            Assert.IsTrue(isAlertPresent(), "Test failed. It should display an alert");
            driver.SwitchTo().Alert().Accept();


            //Try to login with a valid user but without a password
            username = driver.FindElementById("TextBoxUsername");
            username.Clear();
            username.SendKeys("andrea@rpasolution.com");

            password = driver.FindElementById("TextBoxPassword");
            password.Clear();

            login_button = driver.FindElementById("ButtonLogin");
            login_button.Click();

            Assert.IsTrue(isAlertPresent(), "Test failed. It should display an alert");
            //driver.SwitchTo().Alert().Accept();


        }

        public bool isAlertPresent()
        {
            try
            {
                ExpectedConditions.AlertIsPresent();
                return true;
            }   // try 
            catch (NoAlertPresentException Ex)
            {
                return false;
            }   // catch 
        }   // isAlertPresent()

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {

        }
    }
}