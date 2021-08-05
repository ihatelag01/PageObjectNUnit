using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectsWithNUnit.Pages
{
    class ProgressBar
    {
        private string url = "https://www.seleniumeasy.com/test/jquery-download-progress-bar-demo.html";
        private IWebDriver driver;

        public ProgressBar(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"downloadButton\"]")]
        private IWebElement downloadButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"dialog\"]/div[1]")]
        private IWebElement completionStatus;
        

        public void ClickDownloadButton()
        {
            downloadButton.Click();
        }

        public IWebElement ReturnCompletionArea()
        {
            return completionStatus;
        }

        public string ReturnCompletionText()
        {
            return completionStatus.Text;
        }
    }
}
