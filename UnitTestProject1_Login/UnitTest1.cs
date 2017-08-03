using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;


namespace UnitTestProject1_Login
{
    [TestClass]
    public class UnitTest1
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
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(baseURL);

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
