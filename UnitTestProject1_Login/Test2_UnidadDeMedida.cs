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
    public class Test2_UnidadDeMedida
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
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
       
        public void T01_Login() {

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
        public void T02_NavigateToUnidaDeMedida()
        {
            //If the user click in the left menu and click "Unidad de medida" it should redirect them to the "Unidad de medida" page

            //innerText: "Pruebas Page"

            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("fa-sign-out")));

            ReadOnlyCollection<IWebElement> navs = driver.FindElementsByClassName("nav-label");
            bool navFound = false;

            foreach (IWebElement nav in navs) {
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
        public void T03_UsingTheSearchForm() {
        
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[id = 'showModal']")));

            IWebElement searchForm = driver.FindElementByClassName("input-sm");
            searchForm.SendKeys("B");
            ReadOnlyCollection<IWebElement> elements = SearchElements();
            Assert.AreNotEqual(elements, null, "Test failed, it can't find the data");

            string[] data = { "Bolsa", "Bote (16 onz)", "bote (8 oz)", "Bote (8 oz.)", "Botella", "Botella 750 ml", "Libra", "Pie Cubico" };

            for (int i = 0; i < elements.Count; i++)
            {
                Assert.AreEqual(elements[i].Text, data[i], "Search failed to get all the elements");
            }

            IWebElement next_button = driver.FindElementById("gridUnidadMedida_next");
            if (elements.Count <= 10)
            {
                Assert.IsTrue(next_button.GetAttribute("class").Contains("disabled"), "Test failed. The next button should be disabled");
            }


            //If the user cleans the "search" box, it should show them all the elements available again

            searchForm.Clear();
            searchForm.SendKeys(" ");
            ReadOnlyCollection<IWebElement> el = SearchElements();

            string[] allElements = { "Bolsa", "Bote (16 onz)", "bote (8 oz)", "Bote (8 oz.)", "Botella", "Botella 750 ml", "Caja", "Docena", "frasco (16 oz.)", "Galon" };

            for (int i = 0; i < el.Count; i++)
            {
                Assert.IsTrue((el[i].Text).Contains(allElements[i]), "Test failed. It should display all the elements");
            }

            next_button = driver.FindElementById("gridUnidadMedida_next");
            Assert.IsFalse(next_button.GetAttribute("class").Contains("disabled"), "Test failed. The next button should be enabled");


        }

        [TestMethod]
        public void T04_EditMeasureUnit() {

            //Edit the data of a testing element

            IWebElement searchForm = driver.FindElementByClassName("input-sm");
            searchForm.Clear();
            searchForm.SendKeys("botella");

            wait.Until(ExpectedConditions.TextToBePresentInElementValue(searchForm, "Botella"));
            IWebElement next_button = driver.FindElementById("gridUnidadMedida_next");


            ReadOnlyCollection<IWebElement> edit_buttons = driver.FindElementsByClassName("btn-xs");

            foreach (IWebElement edit_button in edit_buttons) {
                if (edit_button.GetAttribute("onclick").Contains("botella")) {
                    System.Diagnostics.Trace.WriteLine(edit_button.Text);
                    wait.Until(ExpectedConditions.ElementToBeClickable(edit_button));
                 //   wait.Until(ExpectedConditions.AlertIsPresent());
                    edit_button.Click();
                }

            }
            

            /*
             <a onclick="ShowUpdateModal(9,'Botella','bt')" class="btn btn-warning btn-xs">Editar</a>
             */


        }


        [ClassCleanup()]
        public static void MyClassCleanup() {
            driver.Quit();
        }



        public bool PruebasPageExpand()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("[href*='Mantenimientos/MantenimientoUnidadMedida.aspx']")));
                return true;
            }
            catch (ElementNotVisibleException ex)
            {
                return false;
            }
        }

        public bool UnidadMedidaClick()
        {
            try
            {
                IWebElement el = driver.FindElementByCssSelector("[href*='Mantenimientos/MantenimientoUnidadMedida.aspx']");
                el.Click();
                wait.Until(ExpectedConditions.UrlToBe("http://localhost:62008/Mantenimientos/MantenimientoUnidadMedida.aspx"));
                return true;
            }
            catch (OpenQA.Selenium.StaleElementReferenceException ex)
            {
                return false;
            }
        }


        public ReadOnlyCollection<IWebElement> SearchElements()
        {
            try
            {
                //<td class="sorting_1"> Bolsa </ td >
                return driver.FindElementsByClassName("sorting_1");
            }
            catch (ElementNotVisibleException ex)
            {
                return null;
            }
        }


    }
}
