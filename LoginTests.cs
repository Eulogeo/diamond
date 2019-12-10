using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestFixture]
    public class LoginTests
    {
        
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); //launches browser
            driver.Manage().Window.Maximize(); //Maximizes window
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
        [Test]
        public void VerifyInvalidLoginWithIncorrectPassword()
        {
            //Open Login page
            driver.Url = "http://the-internet.herokuapp.com/login";
            Console.WriteLine("Opening " + driver.Url);

            //Enter corect Username and wrong Password
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("tomsmith");
            Console.WriteLine("Enter Username and password");

            driver.FindElement(By.XPath("//i[@class='fa fa-2x fa-sign-in']")).Click();
            Assert.IsTrue(driver.PageSource.Contains("Your password is invalid!"));

        }
        [Test]
        public void VerifyInvalidLoginWithIncorrectUsername()
        {
            //Open Login page
            driver.Url = "http://the-internet.herokuapp.com/login";
            Console.WriteLine("Opening " + driver.Url);


            //Enter wrong Username and correct Password
            driver.FindElement(By.Id("username")).SendKeys("smith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            Console.WriteLine("Enter Username and password");

            driver.FindElement(By.XPath("//i[@class='fa fa-2x fa-sign-in']")).Click();
            Assert.IsTrue(driver.PageSource.Contains("Your username is invalid!"));
        }
        [Test]
        public void VerifyValidlogin()
        {
            //Open Login page
            driver.Url = "http://the-internet.herokuapp.com/login";
            Console.WriteLine("Opening " + driver.Url);

            //Enter corect Username and correct Password
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            Console.WriteLine("Enter Username and password");

            driver.FindElement(By.XPath("//i[@class='fa fa-2x fa-sign-in']")).Click();
            Assert.IsTrue(driver.PageSource.Contains("Secure Area"));
            driver.FindElement(By.XPath("//a[@href='/logout']"));
        }
    }
}

