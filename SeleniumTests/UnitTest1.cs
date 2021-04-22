using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using(var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.simplilearn.com");
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d=> ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                //Console.Read();s

                var searchBox = driver.FindElementById("header_srch");
                Assert.IsNotNull(searchBox);

                var footer = driver.FindElementByXPath("//footer[@id='footer']");
                Assert.IsNotNull(footer);

                var loginButton = driver.FindElementByClassName("login");
                Assert.IsNotNull(loginButton);
                loginButton.Click();


                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );

                var pageTitle = driver.PageSource.Contains("Learning on Simplilearn");
                Assert.IsTrue(pageTitle);
            }
        }
    }
}
