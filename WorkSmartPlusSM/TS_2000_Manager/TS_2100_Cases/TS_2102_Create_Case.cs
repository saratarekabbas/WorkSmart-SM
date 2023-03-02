using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V108.Network;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;




namespace WorkSmartPlusSM.Manager.Cases
{
    internal class TS_2101_Create_Case
    {

        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Navigate to Login Page
            driver.Navigate().GoToUrl(AppConfig.WorkSmartPlusPortal);
            driver.FindElement(By.Id("UserName")).SendKeys("Administrator");
            driver.FindElement(By.Id("Password")).SendKeys("Tricubes131");

            //driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            Thread.Sleep(3000);
        }


        //-------------------------------------------------------------------------
        //                              VALID TEST CASES
        //-------------------------------------------------------------------------


        [Test]
        public void TC_2101_CreateCase_ValidData()
        {

            IWebElement manager = driver.FindElement(By.XPath("//a[contains(@class, 'masterlink') and contains(span,'Manager')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(manager).Perform();
            Thread.Sleep(1000);

            // Hover over Cases
            IWebElement cases = driver.FindElement(By.XPath("//a[contains(@href,'/portal/Cases') and text()='Cases']"));
            actions.MoveToElement(cases).Perform();
            Thread.Sleep(1000);

            // Click Create Case
            driver.FindElement(By.XPath("//a[contains(@href,'/portal/Cases/Create') and text()='Create Case']")).Click();
            Thread.Sleep(1000);

            // Assert that the Create Case page has loaded
            //Assert.IsTrue(driver.FindElement(By.XPath("//h1[text()='Create New Case']")).Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
