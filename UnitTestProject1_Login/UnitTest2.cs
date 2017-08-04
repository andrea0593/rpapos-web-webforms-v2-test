using System;
using System.Collections.ObjectModel;
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

        private static string baseURL;
        private static RemoteWebDriver driver;
        private static WebDriverWait wait;
        public TestContext TestContext { get; set; }



        [ClassInitialize()]
        public static void MyClassInitialize(TestContext context) {
            driver = new ChromeDriver();
            baseURL = "http://localhost:62008/Login.aspx";
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [TestMethod]
        public void Login() {


            driver.Navigate().GoToUrl(baseURL);

            //Login using a valid username and password

            IWebElement username = driver.FindElementById("TextBoxUsername");
            username.Clear();
            username.SendKeys("SA");

            IWebElement password = driver.FindElementById("TextBoxPassword");
            password.Clear();
            password.SendKeys("airdogs");

            IWebElement login_button = driver.FindElementById("ButtonLogin");
            login_button.Click();

            Assert.AreEqual(driver.Url, "http://localhost:62008/Test.aspx", "Test failed, it should navigate to the Test.aspx page after a valid login");

        }

        [TestMethod]
        public void NavigateToUnidaDeMedida() {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("fa-sign-out")));
            ReadOnlyCollection<IWebElement> navs = driver.FindElementsByClassName("nav-label");
            bool navFound = false;

            foreach (IWebElement nav in navs) {

                System.Diagnostics.Trace.WriteLine(nav.Text);

                if (nav.Text == "Pruebas Page") {
                    navFound = true;
                    nav.Click();
                    Assert.IsTrue(PruebasPageExpand(), "Test failed, the menu should expand");
                }
            }
            Assert.IsTrue(navFound, "Test failed, it should be a nav menu with the title Pruebas Page");

            Assert.IsTrue(UnidadMedidaClick(), "Test failed, it should redirect to MantenimientoUnidadMedida.aspx");
        }

        [TestMethod]
        public void searchUnidadDeMedida() {

            // < input type = "search" class="form-control input-sm" placeholder="" aria-controls="gridUnidadMedida">
            IWebElement searchForm = driver.FindElementByClassName("input-sm");
            searchForm.SendKeys("B");
            ReadOnlyCollection<IWebElement> elements = searchElements();
            Assert.AreNotEqual(elements, null, "Test failed, it can't find the data");

            string[] data = { "Bolsa", "Bote (16 onz)", "bote (8 oz)", "Bote (8 oz.)", "Botella", "Botella 750 ml", "Libra", "Pie Cubico" };

            for (int i = 0; i< elements.Count; i++) {
               Assert.AreEqual(elements[i].Text, data[i], "Search failed to get all the elements");
            }

            if (elements.Count <= 10) {
                //<a href="#" aria-controls="gridUnidadMedida" data-dt-idx="2" tabindex="0">Next</a>
                ReadOnlyCollection<IWebElement> buttons = driver.FindElementsByClassName("gridUnidadMedida");
                foreach (IWebElement button in buttons) {
                    if (button.Text == "Next") {
                        Assert.IsFalse(button.Enabled, "Test failed. The next button should be disabled");
                    }
                }
                
            }

        }




        public bool PruebasPageExpand() {
            try {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[href*='Mantenimientos/MantenimientoUnidadMedida.aspx']")));
                return true;
            }
            catch (ElementNotVisibleException ex) {
                return false;
            }
        }

        public bool UnidadMedidaClick() {
            try
            {
                IWebElement el = driver.FindElementByCssSelector("[href*='Mantenimientos/MantenimientoUnidadMedida.aspx']");
                el.Click();
                wait.Until(ExpectedConditions.UrlToBe("http://localhost:62008/Mantenimientos/MantenimientoUnidadMedida.aspx"));
                return true;
            }
            catch (OpenQA.Selenium.StaleElementReferenceException ex) {
                return false;
            }
        }

        public ReadOnlyCollection<IWebElement> searchElements() {
            try {
                //<td class="sorting_1"> Bolsa </ td >
                ReadOnlyCollection<IWebElement> elements = driver.FindElementsByClassName("sorting_1");
                return elements;
            }
            catch (ElementNotVisibleException ex) {
                return null;
            }
        }





        [ClassCleanup()]
        public static void MyClassCleanup() {
            driver.Quit();
        }
       




    }
}
