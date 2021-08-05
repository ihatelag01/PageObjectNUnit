using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using PageObjectsWithNUnit.Pages;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PageObjectsWithNUnit.Tests
{
    [TestFixture]
    class ProgressBarTests
    {
        private IWebDriver driver;
        private ProgressBar progressBar;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            progressBar = new ProgressBar(driver);
        }

        [Test]
        public void WaitForDownloadCompletion()
        {
            //Arrange
            string complete = "Complete!";
            progressBar.GoToPage();

            //Act
            progressBar.ClickDownloadButton();
            Thread.Sleep(10000);
            
            //Assert
            Assert.That(progressBar.ReturnCompletionText(),Is.EqualTo(complete));
        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
