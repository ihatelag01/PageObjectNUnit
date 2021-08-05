using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectsWithNUnit.Pages;
using SeleniumExtras.PageObjects;

namespace PageObjectsWithNUnit.Tests
{
    [TestFixture]
    class TablePaginationTests
    {
        private IWebDriver driver;
        private TablePagination table;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            table = new TablePagination(driver);
        }

        [Test]
        public void ValidateSecondPageClick()
        {
            //Arrange
            table.GoToPage();

            //Act
            table.ClickSecondPage();

            //Assert
            Assert.That(table.ReturnNumberOfVisibleRecords(),Is.EqualTo(table.ReturnNumberOfRecords()-table.ReturnNumberOfInvisibleRecords()));
        }

        [Test]
        public void ValidateNextPageClick()
        {
            //Arrange
            table.GoToPage();

            //Act
            table.ClickNextPage();

            //Assert
            Assert.That(table.ReturnNumberOfVisibleRecords(), Is.EqualTo(table.ReturnNumberOfRecords() - table.ReturnNumberOfInvisibleRecords()));
        }

        [Test]
        public void ValidateThirdPageClick()
        {
            //Arrange
            table.GoToPage();

            //Act
            table.ClickThirdPage();

            //Assert
            Assert.That(table.ReturnNumberOfVisibleRecords(), Is.EqualTo(table.ReturnNumberOfRecords() - table.ReturnNumberOfInvisibleRecords()));
        }

        [Test]
        public void ValidatePrevPageClick()
        {
            //Arrange
            table.GoToPage();

            //Act
            table.ClickSecondPage();
            table.ClickPrevPage();

            //Assert
            Assert.That(table.ReturnNumberOfVisibleRecords(), Is.EqualTo(table.ReturnNumberOfRecords() - table.ReturnNumberOfInvisibleRecords()));
        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }

    }
}
