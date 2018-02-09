using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace ACME.Tests.Integrated.Core
{
    [TestClass]
    public class BowlingTests
    {
        //[TestMethod]
        //public void Test_page_model()
        //{
        //    GameHistoryPage page = new GameHistoryPage();

        //    page.AddCode("1111");
        //    page.AssertHas("1,1,1,1,1,1");

        //}

        [TestMethod]
        public void Selenium_Test_for_Bowling()
        {
            IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory());

            driver.Navigate().GoToUrl("http://localhost:8080/modules/main/index.html");

            driver.FindElement(By.Name("score")).SendKeys("1111");

            driver.FindElement(By.Id("score-button")).Click();


            //driver.FindElement(By.Id("game-history"))

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));

            wait.Until(d => d.FindElement(By.Id("game-history")));
            //Assert.AreEqual("Selenium - Web Browser Automation", driver.Title);

            driver.Quit();

        }
    }
}
