using NUnit.Framework;
using SwagLabs.Core.Helpers;
using SwagLabs.Definitions.Support;
using SwagLabs.PageObjects.Pages;

namespace SwagLabs.Definitions.Steps
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly DriverContext context;
        private InventoryPage inventoryPage;
        private InventoryItemPage inventoryItemPage;
        private HeaderPage headerPage;
        private CartPage cartPage;
        private CheckoutStepOnePage checkoutStepOnePage;

        public CheckoutSteps(DriverContext driverContext)
        {
            context = driverContext;
            inventoryPage = new InventoryPage(context.Driver!, context.Config!);
            inventoryItemPage = new InventoryItemPage(context.Driver!, context.Config!);
            headerPage = new HeaderPage(context.Driver!, context.Config!);
            cartPage = new CartPage(context.Driver!, context.Config!);
            checkoutStepOnePage = new CheckoutStepOnePage(context.Driver!, context.Config!);
        }

        [Given("I am on the {string} page")]
        public void GivenIAmOnTheInventoryPage(string pageHeader)
        {
            Assert.That(inventoryPage.ExtractPageHeader(pageHeader), Is.EqualTo(pageHeader));
        }

        [When("I click on {string}")]
        public void WhenIClickOnProduct(string productName)
        {
            inventoryPage.ClickOnProduct(productName);
        }

        [When("I add it to the cart")]
        public void WhenIAddItToTheCart()
        {
            inventoryItemPage.AddToCart();
        }

        [When("I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            headerPage.ClickOnCart();
        }

        [When("I click checkout button")]
        public void WhenIClickCheckoutButton()
        {
            cartPage.ClickCheckoutBtn();

        }

        [Then("I should see the page header {string}")]
        public void ThenIShouldSeeThePageHeader(string expectedHeader)
        {
            Assert.That(checkoutStepOnePage.ExtractPageTitle(), Is.EqualTo(expectedHeader));
        }

        [Then("the following fields should be visible")]
        public void ThenTheFollowingFieldsShouldBeVisible(DataTable dataTable)
        {
            foreach (var row in dataTable.Rows)
            {
                var fieldLabel = row[0];
                Assert.That(checkoutStepOnePage.IsFieldVisible(fieldLabel), Is.True,
                    $"Expected field '{fieldLabel}' to be visible");
            }
        }

        [Then("a {string} button should be visible")]
        public void ThenAButtonShouldBeVisible(string buttonName)
        {
            Assert.That(checkoutStepOnePage.IsButtonVisible(buttonName), Is.True,
                $"Expected '{buttonName}' button to be visible");
        }

    }
}
