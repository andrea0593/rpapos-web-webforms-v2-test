using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1_Login
{
    [TestClass]
    public class UnitTest2
    {

        private string baseURL = "http://localhost:62008/Login.aspx";
        private RemoteWebDriver driver = new ChromeDriver();
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(1)]
        [Owner("Chrome")]

        public void TestMethod2()
        {
       
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(15));
            driver.Navigate().GoToUrl(baseURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Login using a valid username and password

            IWebElement username = driver.FindElementById("TextBoxUsername");
            username.Clear();
            username.SendKeys("SA");

            IWebElement password = driver.FindElementById("TextBoxPassword");
            password.Clear();
            password.SendKeys("airdogs");

            IWebElement login_button = driver.FindElementById("ButtonLogin");
            login_button.Click();

            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(15));
            Assert.AreEqual(driver.Url, "http://localhost:62008/Test.aspx");




        }

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
