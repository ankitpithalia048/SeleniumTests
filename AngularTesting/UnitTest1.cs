using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;

namespace AngularTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:4200/");
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                //Console.Read();s

                var fname = driver.FindElementByClassName("fname");
                Assert.IsNotNull(fname);
                fname.SendKeys("Ankit");
                WebDriverWait enterFname = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                
                var lname = driver.FindElementByClassName("lname");
                Assert.IsNotNull(lname);
                lname.SendKeys("Pithalia");
                WebDriverWait enterlname = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); 
                
                var email = driver.FindElementByClassName("email");
                Assert.IsNotNull(email);
                email.SendKeys("Ankit@gmail");
                WebDriverWait enteremail = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                
                var phone = driver.FindElementByClassName("phone");
                Assert.IsNotNull(phone);
                phone.SendKeys("7898619861");
                WebDriverWait enterphone = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                var username = driver.FindElementByClassName("username");
                Assert.IsNotNull(username);
                username.SendKeys("ankit");
                WebDriverWait enterusername = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                
                var pass = driver.FindElementByClassName("password");
                Assert.IsNotNull(pass);
                pass.SendKeys("ankit");
                WebDriverWait enterpass = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IWebElement signUpClick = driver.FindElementByClassName("registerbutton");
                signUpClick.Click();
                WebDriverWait waitForControl = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                /* Console.Read();*/
                var text = driver.PageSource.Contains("Angular Testing");
                
                if (text)
                {
                    var check = driver.PageSource.Contains("Selenium");
                    Assert.IsTrue(check);
                    
                    driver.Quit();
                }
                else
                {
                    
                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    ss.SaveAsFile("D:\\simplilearn .net\\error.png", OpenQA.Selenium.ScreenshotImageFormat.Png);
                    Assert.IsTrue(text);
                }



            }


        }
    }
}
