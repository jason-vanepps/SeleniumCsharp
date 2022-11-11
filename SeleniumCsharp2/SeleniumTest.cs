using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace SeleniumCsharp

{

    public class Tests

    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {

            //Below code is to get the drivers folder path dynamically.

            string path = Directory.GetParent(path: Environment.CurrentDirectory).Parent.Parent.FullName;

            driver= new FirefoxDriver(path + "\\drivers\\");

        }

        [Test]
        public void VerifyLogo()
        {

            driver.Navigate().GoToUrl("http://www.jvanepps.com");
            Assert.IsTrue(driver.FindElement(By.Id("logo")).Displayed);

        }

        [Test]
        public void VerifyAbout()
        {
            driver.Navigate().GoToUrl("http://www.jvanepps.com");
            System.Threading.Thread.Sleep(2000);

            IWebElement MenuCheck = driver.FindElement(By.ClassName("hamburger"));
            Assert.AreEqual(MenuCheck.Displayed, true);
            MenuCheck.Click();

            WebDriverWait waitObject = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            IWebElement LinkCheck = waitObject.Until<IWebElement>(d => d.FindElement(By.LinkText("About Jason")));
            IWebElement JayLink = driver.FindElement(By.LinkText("About Jason"));
            JayLink.Click();
            IWebElement FindWord = driver.FindElement(By.TagName("h2"));
            Assert.IsTrue(FindWord.Text.Contains("About"));
        }

        [Test]
        public void TestInput()
        {
            driver.Navigate().GoToUrl("http://www.jvanepps.com");
            System.Threading.Thread.Sleep(2000);

            IWebElement MenuCheck = driver.FindElement(By.ClassName("hamburger"));
            Assert.AreEqual(MenuCheck.Displayed, true);
            MenuCheck.Click();

            WebDriverWait waitObject2 = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            IWebElement References = waitObject2.Until<IWebElement>(d => d.FindElement(By.LinkText("References")));
            IWebElement JayRefer = driver.FindElement(By.LinkText("References"));
            JayRefer.Click();

            WebDriverWait waitObject3 = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            IWebElement TextInput = driver.FindElement(By.Name("p"));
            TextInput.Click();
            Assert.IsEmpty(TextInput.Text);
            TextInput.SendKeys("Lotro2010");
            IWebElement Login = driver.FindElement(By.Id("submit-password"));
            Login.Click();
            IWebElement FindWord2 = driver.FindElement(By.ClassName("weebly-footer"));

        }

        [OneTimeTearDown]
        public void TearDown()
        {

            driver.Quit();

        }

    }

}