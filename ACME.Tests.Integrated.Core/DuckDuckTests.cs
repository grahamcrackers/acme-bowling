using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace ACME.Tests.Integrated.Core
{
    [TestClass]
    public class DuckDuckTests
    {
        [TestMethod]
        public void Selenium_Test_for_Duck_Duck_Go()
        {
            IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory());

            driver.Navigate().GoToUrl("http://www.duckduckgo.com");

            driver.FindElement(By.Id("search_form_input_homepage")).SendKeys("selenium");

            driver.FindElement(By.Id("search_button_homepage")).Click();

            driver.FindElement(By.LinkText("Selenium - Web Browser Automation")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));

            wait.Until(d => d.Title == "Selenium - Web Browser Automation");
            //Assert.AreEqual("Selenium - Web Browser Automation", driver.Title);

            driver.Quit();

        }
    }
}
