using March2023.Pages;
using March2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class EmployeeTests : CommonDriver
    {

        // Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        EmployeePage employeePageObj = new EmployeePage();

        [SetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();

            loginPageObj.LoginSteps(driver);

            
            homePageObj.GoToEmployeePage();
        }

        [Test]
        public void CreateEmployee_Test()
        {
            
            employeePageObj.CreateEmployee();
        }

        [Test]
        public void EditEmployee_Test()
        {
  
            employeePageObj.EditEmployee();
        }

        [Test]
        public void DeleteEmployee_Test()
        {

            employeePageObj.DeleteEmployee();
        }

        [TearDown]
        public void ClosingSteps()
        {
            driver.Quit();
        }
    }
}
