using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace WorkSmartPlusSM.Manager.Cases
{
    internal class TS_1101_Admin_Login
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            // Navigate to Login Page
            driver.Navigate().GoToUrl(AppConfig.WorkSmartPlusPortal);

            // Create an instance of the login page object
            //loginPage = new LoginPage(driver);

            // Login

        }

        //-------------------------------------------------------------------------
        //                              VALID TEST CASES
        //-------------------------------------------------------------------------

        [Test]
        public void TC_1101_LoginAdmin_ValidData()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("Administrator");
            driver.FindElement(By.Id("Password")).SendKeys("Tricubes131");

            //driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            Thread.Sleep(3000);
            String successMessage = driver.FindElement(By.ClassName("username")).Text;
            TestContext.Progress.WriteLine(successMessage);

            //driver.Close(); //closes only the originally opened window
            driver.Quit(); //Quits all windows that were caused by automation
        }

        //-------------------------------------------------------------------------
        //                             INVALID TEST CASES
        //-------------------------------------------------------------------------

        [Test]
        public void TC_1102_LoginAdmin_InvalidData_Username()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("x");
            driver.FindElement(By.Id("Password")).SendKeys("Tricubes131");

            //driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            String expectedErrorMessage = "You must specify a valid username and password."; //You must specify a valid username and password
            String actualErrorMessage = driver.FindElement(By.ClassName("error")).Text; //You must specify a valid username and password

            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"FAIL: Actual error message '{actualErrorMessage}' does not match expected error message '{expectedErrorMessage}'.");

            //driver.Close(); //closes only the originally opened window
            driver.Quit(); //Quits all windows that were caused by automation
        }

        [Test]
        public void TC_1103_LoginAdmin_InvalidData_Password()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("Administrator");
            driver.FindElement(By.Id("Password")).SendKeys("x");

            //driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            String expectedErrorMessage = "You must specify a valid username and password."; //You must specify a valid username and password
            String actualErrorMessage = driver.FindElement(By.ClassName("error")).Text; //You must specify a valid username and password

            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"FAIL: Actual error message '{actualErrorMessage}' does not match expected error message '{expectedErrorMessage}'.");

            //driver.Close(); //closes only the originally opened window
            driver.Quit(); //Quits all windows that were caused by automation
        }

        [Test]
        public void TC_1104_LoginAdmin_InvalidData_UsernamePassword()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("Administratorxx");
            driver.FindElement(By.Id("Password")).SendKeys("Tricubes131xxx");

            //driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            String expectedErrorMessage = "You must specify a valid username and password."; //You must specify a valid username and password
            String actualErrorMessage = driver.FindElement(By.ClassName("error")).Text; //You must specify a valid username and password

            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"FAIL: Actual error message '{actualErrorMessage}' does not match expected error message '{expectedErrorMessage}'.");

            //driver.Close(); //closes only the originally opened window
            driver.Quit(); //Quits all windows that were caused by automation
        }

        //-------------------------------------------------------------------------
        //                             EMPTY TEST CASES
        //-------------------------------------------------------------------------

        [Test]
        public void TC_1105_LoginAdmin_EmptyData_Username()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("");
            driver.FindElement(By.Id("Password")).SendKeys("123456789");

            //driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            String expectedErrorMessage = "You must specify a valid username and password."; //You must specify a valid username and password
            String actualErrorMessage = driver.FindElement(By.ClassName("error")).Text; //You must specify a valid username and password

            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"FAIL: Actual error message '{actualErrorMessage}' does not match expected error message '{expectedErrorMessage}'.");

            //driver.Close(); //closes only the originally opened window
            driver.Quit(); //Quits all windows that were caused by automation
        }

        [Test]
        public void TC_1106_LoginAdmin_EmptyData_Password()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("Administrator");
            driver.FindElement(By.Id("Password")).SendKeys("");

            //driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            String expectedErrorMessage = "You must specify a valid username and password."; //You must specify a valid username and password
            String actualErrorMessage = driver.FindElement(By.ClassName("error")).Text; //You must specify a valid username and password

            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"FAIL: Actual error message '{actualErrorMessage}' does not match expected error message '{expectedErrorMessage}'.");

            //driver.Close(); //closes only the originally opened window
            driver.Quit(); //Quits all windows that were caused by automation
        }

        [Test]
        public void TC_1107_LoginAdmin_EmptyData_UsernamePassword()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("");
            driver.FindElement(By.Id("Password")).SendKeys("");

            //driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            String expectedErrorMessage = "You must specify a valid username and password."; //You must specify a valid username and password
            String actualErrorMessage = driver.FindElement(By.ClassName("error")).Text; //You must specify a valid username and password

            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"FAIL: Actual error message '{actualErrorMessage}' does not match expected error message '{expectedErrorMessage}'.");
              }

        [TearDown]
        public void TearDown()
        {
            //driver.Close(); //closes only the originally opened window
            driver.Quit(); //Quits all windows that were caused by automation
        }
    }
}
