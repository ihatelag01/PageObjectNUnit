using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectsWithNUnit.Pages
{
    class TablePagination
    {
        private IWebDriver driver;
        private string url = "https://www.seleniumeasy.com/test/table-pagination-demo.html";

        public TablePagination(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"myPager\"]/li[3]/a")]
        private IWebElement secondPageBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"myPager\"]/li[4]/a")]
        private IWebElement thirdPageBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"myPager\"]/li[5]/a")]
        private IWebElement nextPageBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"myPager\"]/li[1]/a")]
        private IWebElement prevPageBtn;

        [FindsBy(How=How.TagName, Using = "tr")]
        private IList<IWebElement> listOfRecords;

        public int ReturnNumberOfRecords()
        {
            return listOfRecords.Count - 1;
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public int ReturnNumberOfVisibleRecords()
        {
            int visibleCount = ReturnNumberOfRecords();

            foreach (var record in listOfRecords)
            {
                if (!record.Displayed)
                {
                    visibleCount--;
                }
            }

            return visibleCount;
        }

        public int ReturnNumberOfInvisibleRecords()
        {
            int invisibleCount = 0;

            foreach (var record in listOfRecords)
            {
                if (!record.Displayed)
                {
                    invisibleCount++;
                }
            }

            return invisibleCount;
        }

        public void ClickSecondPage()
        {
            secondPageBtn.Click();
        }

        public void ClickThirdPage()
        {
            thirdPageBtn.Click();
        }

        public void ClickPrevPage()
        {
            prevPageBtn.Click();
        }

        public void ClickNextPage()
        {
            nextPageBtn.Click();
        }


    }
}
