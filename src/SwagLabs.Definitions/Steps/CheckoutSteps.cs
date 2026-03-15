using NUnit.Framework;
using SwagLabs.Core.Helpers;
using SwagLabs.Definitions.Support;
using SwagLabs.PageObjects.Components;
using SwagLabs.PageObjects.Pages;
using System.Diagnostics.Metrics;

namespace SwagLabs.Definitions.Steps
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly DriverContext context;
        private readonly InventoryPage inventoryPage;
        private readonly InventoryItemPage inventoryItemPage;
        private readonly HeaderPage headerPage;
        private readonly CartPage cartPage;
        private readonly CheckoutStepOnePage checkoutStepOnePage;

        public CheckoutSteps(DriverContext driverContext, InventoryPage inventoryPage, InventoryItemPage inventoryItemPage, HeaderPage headerPage, CartPage cartPage, CheckoutStepOnePage checkoutStepOnePage)
        {
            context = driverContext;
            this.inventoryPage = inventoryPage;
            this.inventoryItemPage = inventoryItemPage;
            this.headerPage = headerPage;
            this.cartPage = cartPage;
            this.checkoutStepOnePage = checkoutStepOnePage;
        }

        [Given("I am on the {string} page")]
        public void GivenIAmOnTheInventoryPage(string pageHeader)
        {
            Assert.That(headerPage.ExtractPageTitle(), Is.EqualTo(pageHeader));
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
            Assert.That(headerPage.ExtractPageTitle(), Is.EqualTo(expectedHeader));
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

        [When("I enter first name {string}")]
        public void WhenIEnterFirstName(string firstName)
        {
            checkoutStepOnePage.EnterFirstName(firstName);
        }

        [When("I enter last name {string}")]
        public void WhenIEnterLastName(string lastName)
        {
            checkoutStepOnePage.EnterLastName(lastName);
        }


        [When("I enter zip code {string}")]
        public void WhenIEnterZipCode(string zipCode)
        {
            checkoutStepOnePage.EnterZipCode(zipCode);
        }

        [When("I click on continue button")]
        public void WhenIClickOnContinueButton()
        {
            checkoutStepOnePage.ClickOnContinueBtn();
        }

        [Then("I should be on the checkout step two page")]
        public void ThenIShouldBeOnTheCheckoutStepTwoPage()
        {
            WaitHelper.WaitForUrl(context.Driver, "checkout-step-two");
            Assert.That(context.Driver.Url, Does.Contain("checkout-step-two"));
        }
    }
}
