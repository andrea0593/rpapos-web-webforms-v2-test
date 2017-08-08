using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;


namespace UnitTestProject1_Login
{
    [TestClass]
    public class LoginTest
    {

        private static string baseURL;
        private static RemoteWebDriver driver;
        private static WebDriverWait wait;
        public TestContext TestContext { get; set; }


        [ClassInitialize()]
        public static void MyClassInitialize(TestContext context)
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:62008/Login.aspx";
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [TestMethod]
        public void Login()
        {
            //Navigate to the login page and try to login with an invalid user and password
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

            Assert.AreEqual(driver.Url, baseURL);


            //Login using a valid username and password
            username = driver.FindElementById("TextBoxUsername");
            username.Clear();
            username.SendKeys("SA");

            password = driver.FindElementById("TextBoxPassword");
            password.Clear();
            password.SendKeys("airdogs");

            login_button = driver.FindElementById("ButtonLogin");
            login_button.Click();

            Assert.AreEqual(driver.Url, "http://localhost:62008/Test.aspx");
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




        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            driver.Quit();
        }
    }

}
