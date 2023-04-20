using March2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace March2023.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {

            // click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            // select Time option from dropdown
            IWebElement dropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            dropdown.Click();
            Thread.Sleep(1000);

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            // type code into code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("March2023");

            // type description into description textbox
            driver.FindElement(By.Id("Description")).SendKeys("March2023");

            // type price into price per unit textbox
            IWebElement priceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceOverlap.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            // click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);

            // check if new Time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1000);
        }

        public string GetCode(IWebDriver driver)
        {
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return actualCode.Text;
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return actualDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return actualPrice.Text;
        }





        public void EditTM(IWebDriver driver, string description, string code, string price)
        {
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Thread.Sleep(4000);
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")); 

            if(newCode.Text == "March2023")
            {
                //click on edit button
                Thread.Sleep(1000);

                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[last()]/a[1]"));
                editButton.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Assert.Fail("Record recently created hasn't been found");
            }

            //select Time option from dropdown
            IWebElement dropdownEdit = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            dropdownEdit.Click();
            Thread.Sleep(500);

            IWebElement timeOptionEdit = driver.FindElement(By.XPath("//*[@id=\"TypeCode-list\"]"));
            timeOptionEdit.Click();

            //edit code into code textbox
            IWebElement editcodeTextbox = driver.FindElement(By.XPath("//*[@id=\"Code\"]"));
            editcodeTextbox.Clear();
            editcodeTextbox.SendKeys(code);

            //edit description into description boxr1q
            IWebElement editdescriptionTextbox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            editdescriptionTextbox.Clear();
            editdescriptionTextbox.SendKeys(description);

            //edit price into price per unit textbox
            IWebElement editpriceOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editpriceTextbox = driver.FindElement(By.Id("Price"));

            editpriceOverlap.Click();
            editpriceTextbox.Clear();
            editpriceOverlap.Click();
            editpriceTextbox.SendKeys(price);

            //click on save button
            IWebElement savebuttonEdit = driver.FindElement(By.Id("SaveButton"));
            savebuttonEdit.Click();
            Thread.Sleep(2000);


            //check if Time record has been edited
            IWebElement goToEditLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToEditLastPageButton.Click();
            Thread.Sleep(1500);             
        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
        }

        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;
        }

        public string GetEditedPrice(IWebDriver driver)
        {
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return editedPrice.Text;
        }

        public void DeleteTM(IWebDriver driver)
        {
            Thread.Sleep(4000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Thread.Sleep(4000);
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (editedCode.Text == "TenyIC23Edit")
            {
                //click on delete button
                Thread.Sleep(2000);
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
            }
            else
            {
                Assert.Fail("Record recently created hasn't been found");
            }

            //Popup window Delete confirmation
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            //check the record deleted successfully
            IWebElement deleteCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(deleteCode.Text != "TenyIC23Edit", "Record hasn't been deleted");
        }
    }
}
