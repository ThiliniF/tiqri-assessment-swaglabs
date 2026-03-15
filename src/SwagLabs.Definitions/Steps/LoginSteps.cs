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

        public LoginSteps(DriverContext driverContext, LoginPage loginPage)
        {
            context = driverContext;
            this.loginPage = loginPage;
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            loginPage.NavigateToLoginPage();
        }

        [When ("I login as a standard user")]
        public void WhenILoginAsAStandardUser()
        {
            loginPage.EnterUsername(context.Config.Username);
            loginPage.EnterPassword(context.Config.Password);
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
