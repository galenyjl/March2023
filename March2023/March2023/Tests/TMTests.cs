using March2023.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using March2023.Utilities;

namespace March2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TMTests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObject = new TMPage();

        [SetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();
           
            loginPageObj.LoginSteps(driver);
            homePageObj.GoToTMPage();
        }

        [Test, Order (1), Description ("This test checks if a user is able to create a new TM record")]
        public void CreateTM_Test()
        {
            // TM page object initialization and definition
            
            tmPageObject.CreateTM();
        }

        [Test, Order (2), Description("This test checks if a user is able to edit an existing TM record")]
        public void EditTM_Test()
        {

            tmPageObject.EditTM();
        }

        [Test, Order (3), Description("This test checks if a user is able to delete an existing TM record")]
        public void DeleteTM_Test()
        {

            tmPageObject.DeleteTM();
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
