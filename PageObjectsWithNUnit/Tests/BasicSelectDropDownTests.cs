using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectsWithNUnit.Pages;

namespace PageObjectsWithNUnit.Tests
{
    [TestFixture]
    class BasicSelectDropDownTests
    {
        private IWebDriver driver;
        private BasicSelectDropDown basicSelect;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            basicSelect = new BasicSelectDropDown(driver);
        }

        [Test]
        public void ValidateSelectedDay()
        {
            //Arrange
            string day = "Monday";
            basicSelect.GoToPage();

            //Act
            basicSelect.SelectDay(day);

            //Assert
            Assert.That(basicSelect.ReturnSelectedDayText(),Is.EqualTo(day));
        }

        [Test]
        public void ValidateMultiSelect()
        {
            //Arrange
            string state1 = "California";
            string state2 = "Texas";
            basicSelect.GoToPage();

            //Act
            IList<IWebElement> selectedStates = basicSelect.SelectStateMultiSelect(state1,state2);

            //Assert
            bool isTrue = false;
            foreach (var state in selectedStates)
            {
                if (state.Text==state1 || state.Text==state2)
                {
                    isTrue = true;
                    Assert.IsTrue(isTrue);
                }  
            } 
            

        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
