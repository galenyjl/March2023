using March2023.Pages;
using NUnit.Framework;
using March2023.Utilities;

namespace March2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TMTests : CommonDriver
    {
        HomePage homePageObj = new HomePage();
        TMPage tmPageObject = new TMPage();

        [Test, Order (1), Description ("This test checks if a user is able to create a new TM record")]
        public void CreateTM_Test()
        {
            homePageObj.GoToTMPage(driver);
            tmPageObject.CreateTM(driver);
        }

        [Test, Order (2), Description("This test checks if a user is able to edit an existing TM record")]
        public void EditTM_Test()
        {
            homePageObj.GoToTMPage(driver);
            //tmPageObject.EditTM(driver);
        }

        [Test, Order (3), Description("This test checks if a user is able to delete an existing TM record")]
        public void DeleteTM_Test()
        {
            homePageObj.GoToTMPage(driver);
            tmPageObject.DeleteTM(driver);
        }
    }
}
