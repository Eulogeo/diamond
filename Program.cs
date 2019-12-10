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
    public class Answer_Digital_test
    {
        public static void Main(string [] args)
        {
            Console.WriteLine("Main method");
        }
      
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
        public void VerifyInfiniteScroll()
        {
            //Open page
            driver.Url = "http://the-internet.herokuapp.com/infinite_scroll";
            Console.WriteLine("Opening " + driver.Url);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,1536)", "");
            Assert.IsTrue(driver.PageSource.Contains("Infinite Scroll"));

        }
        [Test]
        public void VerifyKeyPresses()
        {
            //Open page
            driver.Url = "http://the-internet.herokuapp.com/key_presses";
            Console.WriteLine("Opening " + driver.Url);

            driver.FindElement(By.Id("target")).SendKeys(Keys.Tab);
            Assert.IsTrue(driver.PageSource.Contains("TAB"));
            driver.FindElement(By.Id("target")).SendKeys(Keys.Enter);
            Assert.IsTrue(driver.PageSource.Contains("ENTER"));
            driver.FindElement(By.Id("target")).SendKeys(Keys.Escape);
            Assert.IsTrue(driver.PageSource.Contains("ESCAPE"));
            driver.FindElement(By.Id("target")).SendKeys(Keys.Space);
            Assert.IsTrue(driver.PageSource.Contains("SPACE"));

        }

    }

}
