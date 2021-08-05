using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectsWithNUnit.Pages;

namespace PageObjectsWithNUnit.Tests
{
    [TestFixture]
    class TableSearchFilterTests
    {
        private IWebDriver driver;
        private TableSearchFilter tableSearch;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            tableSearch = new TableSearchFilter(driver);
        }

        [Test]
        public void ValidateSearchByTask()
        {
            //Arrange
            string task = "Wire";
            tableSearch.GoToPage();

            //Act
            tableSearch.EnterSearchText(task);

            //Assert
            StringAssert.Contains(task,tableSearch.ReturnTaskString());
        }


        [Test]
        public void ValidateSearchByAssignee()
        {
            //Arrange
            string assignee = "John";
            tableSearch.GoToPage();

            //Act
            tableSearch.EnterSearchText(assignee);

            //Assert
            StringAssert.Contains(assignee, tableSearch.ReturnAssigneeString());
        }


        [Test]
        public void ValidateSearchByStatus()
        {
            //Arrange
            string status = "progress";
            tableSearch.GoToPage();

            //Act
            tableSearch.EnterSearchText(status);

            //Assert
            StringAssert.Contains(status, tableSearch.ReturnStatusString());
        }

        [Test]
        public void ValidateListedUsersIdSearch()
        {
            //Arrange
            string id = "1";
            tableSearch.GoToPage();

            //Act
            tableSearch.SearchListedUsersById(id);

            //Assert
            StringAssert.Contains(id,tableSearch.ReturnIdCellText());
        }

        [Test]
        public void ValidateUsernameSearch()
        {
            //Arrange
            string username = "jacobs";
            tableSearch.GoToPage();

            //Act
            tableSearch.SearchListedUsersByUsername(username);

            //Assert
            StringAssert.Contains(username,tableSearch.ReturnUsernameCellText());
        }

        [Test]
        public void ValidateFirstNameSearch()
        {
            //Arrange
            string firstname = "Byron";
            tableSearch.GoToPage();

            //Act
            tableSearch.SearchListedUsersByFirstName(firstname);

            //Assert
            StringAssert.Contains(firstname,tableSearch.ReturnFirstNameText());
        }

        [Test]
        public void ValidateLastNameSearch()
        {
            //Arrange
            string lastname = "Swarroon";
            tableSearch.GoToPage();

            //Act
            tableSearch.SearchListedUsersByLastName(lastname);

            //Assert
            StringAssert.Contains(lastname,tableSearch.ReturnLastNameText());
        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
