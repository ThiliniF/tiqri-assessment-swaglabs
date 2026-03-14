using NUnit.Framework;
using SwagLabs.Core.Helpers;
using SwagLabs.Definitions.Support;
using SwagLabs.PageObjects.Pages;

namespace SwagLabs.Definitions.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly DriverContext context;
        private LoginPage loginPage;

        public LoginSteps(DriverContext driverContext)
        {
            context = driverContext;
            loginPage = new LoginPage(context.Driver!, context.Config!);
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            loginPage.NavigateToLoginPage();
        }

        [When ("I login with username {string} and password {string}")]
        public void WhenILoginWithUsernameAndPassword(string username, string password)
        {
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.ClickOnLoginBtn();
        }

        [Then ("I should be on the inventory page")]
        public void ThenIShouldBeOnTheInventoryPage()
        {
            WaitHelper.WaitForUrl(context.Driver, "inventory");
            Assert.That(context.Driver.Url, Does.Contain("inventory"));
        }
        
    }
}
