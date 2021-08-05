using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PageObjectsWithNUnit.Pages
{
    class BasicSelectDropDown
    {
        private string url = " https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private IWebDriver driver;

        public BasicSelectDropDown(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"select-demo\"]")]
        private IWebElement basicSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"multi-select\"]")]
        private  IWebElement multiSelect;

        public void SelectDay(string day)
        {
            SelectElement selectedDay = new SelectElement(basicSelect);
            selectedDay.SelectByText(day);
        }

        public string ReturnSelectedDayText()
        {
            return basicSelect.GetProperty("value");
        }

        public IList<IWebElement> SelectStateMultiSelect(string state1, string state2)
        {
            SelectElement selectStates = new SelectElement(multiSelect);
            selectStates.SelectByText(state1);
            selectStates.SelectByText(state2);
            return selectStates.AllSelectedOptions;
        }
    }
}
