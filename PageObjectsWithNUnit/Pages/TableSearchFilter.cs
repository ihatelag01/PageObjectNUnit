using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectsWithNUnit.Pages
{
    class TableSearchFilter
    {
        private string url = "https://www.seleniumeasy.com/test/table-search-filter-demo.html";
        private IWebDriver driver;

        public TableSearchFilter(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"task-table-filter\"]")]
        private IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"task-table\"]/tbody/tr[1]/td[2]")]
        private IWebElement taskRow;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"task-table\"]/tbody/tr[1]/td[3]")]
        private IWebElement assigneeRow;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"task-table\"]/tbody/tr[1]/td[4]")]
        private IWebElement statusRow;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/div/div/div/button")]
        private IWebElement filterBtn;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/div/table/thead/tr/th[1]/input")]
        private IWebElement idSearchInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/div/table/tbody/tr[1]/td[1]")]
        private IWebElement idCell;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/div/table/thead/tr/th[2]/input")]
        private IWebElement userNameSearchInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/div/table/tbody/tr[1]/td[2]")]
        private IWebElement userNameCell;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/div/table/thead/tr/th[3]/input")]
        private IWebElement firstNameSearchInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/div/table/tbody/tr[1]/td[3]")]
        private IWebElement firstNameCell;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/div/table/thead/tr/th[4]/input")]
        private IWebElement lastNameSearchInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/div[2]/div/table/tbody/tr[2]/td[4]")]
        private IWebElement lastNameCell;


        public void EnterSearchText(string str)
        {
            searchInput.SendKeys(str);
        }

        public string ReturnTaskString()
        {
            return taskRow.Text;
        }

        public string ReturnAssigneeString()
        {
            return assigneeRow.Text;
        }

        public string ReturnStatusString()
        {
            return statusRow.Text;
        }

        public void SearchListedUsersById(string id)
        {
            filterBtn.Click();
            idSearchInput.SendKeys(id);
        }

        public string ReturnIdCellText()
        {
            return idCell.Text;
        }

        public void SearchListedUsersByUsername(string username)
        {
            filterBtn.Click();
            userNameSearchInput.Click();
            userNameSearchInput.SendKeys(username);
        }

        public string ReturnUsernameCellText()
        {
            return userNameCell.Text;
        }

        public void SearchListedUsersByFirstName(string firstName)
        {
            filterBtn.Click();
            firstNameSearchInput.Click();
            firstNameSearchInput.SendKeys(firstName);
        }

        public string ReturnFirstNameText()
        {
            return firstNameCell.Text;
        }

        public void SearchListedUsersByLastName(string lastName)
        {
            filterBtn.Click();
            lastNameSearchInput.Click();
            lastNameSearchInput.SendKeys(lastName);
        }

        public string ReturnLastNameText()
        {
            return lastNameCell.Text;
        }
    }
}
