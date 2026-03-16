using NUnit.Framework;
using SwagLabs.Core.Helpers;
using SwagLabs.Definitions.Support;
using SwagLabs.PageObjects.Components;
using SwagLabs.PageObjects.Pages;

namespace SwagLabs.Definitions.Steps
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly DriverContext context;
        private readonly ScenarioContext scenarioContext;
        private readonly InventoryPage inventoryPage;
        private readonly InventoryItemPage inventoryItemPage;
        private readonly HeaderPage headerPage;
        private readonly CartPage cartPage;
        private readonly CheckoutStepOnePage checkoutStepOnePage;
        private readonly CheckoutStepTwoPage checkoutStepTwoPage;
        private readonly CheckoutCompletePage checkoutCompletePage;

        public CheckoutSteps(DriverContext driverContext,
            ScenarioContext scenarioContext,
            InventoryPage inventoryPage,
            InventoryItemPage inventoryItemPage,
            HeaderPage headerPage,
            CartPage cartPage,
            CheckoutStepOnePage checkoutStepOnePage,
            CheckoutStepTwoPage checkoutStepTwoPage,
            CheckoutCompletePage checkoutCompletePage)
        {
            context = driverContext;
            this.scenarioContext = scenarioContext;
            this.inventoryPage = inventoryPage;
            this.inventoryItemPage = inventoryItemPage;
            this.headerPage = headerPage;
            this.cartPage = cartPage;
            this.checkoutStepOnePage = checkoutStepOnePage;
            this.checkoutStepTwoPage = checkoutStepTwoPage;
            this.checkoutCompletePage = checkoutCompletePage;
        }

        [Given("I am on the {string} page")]
        public void GivenIAmOnThePage(string pageHeader)
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
                var fieldLabel = row["Field"];
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

        [When("I add the following items to the cart")]
        public void WhenIAddTheFollowingItemsToTheCart(DataTable dataTable)
        {
            foreach (var row in dataTable.Rows)
            {
                inventoryPage.AddItemToCart(row["Item"]);
            }
        }

        [Then("the cart should contain")]
        public void ThenTheCartShouldContain(DataTable dataTable)
        {
            var expectedItems = dataTable.Rows.Select(r => r["Item"]).ToList();
            var actualItems = cartPage.GetCartItemNames();
            Assert.That(actualItems, Is.EquivalentTo(expectedItems),
                $"Expected cart to contain: {string.Join(", ", expectedItems)}");
        }
        [When("I get the item price as {string}")]
        public void WhenIGetTheItemPriceAs(string itemPrice)
        {
            scenarioContext[itemPrice] = inventoryItemPage.GetItemPrice();
        }

        [Then("the price should display {string}")]
        public void ThenThePriceShouldDisplay(string itemPrice)
        {
            var expectedPrice = (decimal)scenarioContext[itemPrice];
            var displayedPrices = checkoutStepTwoPage.GetItemPrices();
            Assert.That(displayedPrices, Does.Contain(expectedPrice),
                $"Expected price ${expectedPrice} to be displayed on the overview page");
        }

        [Then("I should see the payment information")]
        public void ThenIShouldSeeThePaymentInformation()
        {
            Assert.That(checkoutStepTwoPage.IsPaymentInfoDisplayed(), Is.True,
                "Expected payment information to be displayed");
        }

        [Then("I should see the shipping information")]
        public void ThenIShouldSeeTheShippingInformation()
        {
            Assert.That(checkoutStepTwoPage.IsShippingInfoDisplayed(), Is.True,
                "Expected shipping information to be displayed");
        }

        [Then("I should see the item total")]
        public void ThenIShouldSeeTheItemTotal()
        {
            Assert.That(checkoutStepTwoPage.GetItemTotal(), Is.GreaterThan(0),
                "Expected item total to be displayed and greater than zero");
        }

        [Then("I should see the tax amount")]
        public void ThenIShouldSeeTheTaxAmount()
        {
            Assert.That(checkoutStepTwoPage.GetTax(), Is.GreaterThan(0),
                "Expected tax amount to be displayed and greater than zero");
        }

        [Then("the order total should be the sum of item total and tax")]
        public void ThenTheOrderTotalShouldBeTheSumOfItemTotalAndTax()
        {
            var itemTotal = checkoutStepTwoPage.GetItemTotal();
            var tax = checkoutStepTwoPage.GetTax();
            var orderTotal = checkoutStepTwoPage.GetOrderTotal();
            Assert.That(orderTotal, Is.EqualTo(itemTotal + tax).Within(0.01m),
                $"Expected order total ${orderTotal} to equal item total ${itemTotal} + tax ${tax}");
        }

        [When("I click on the finish button")]
        public void WhenIClickOnTheFinishButton()
        {
            checkoutStepTwoPage.clickOnFinishBtn();
        }

        [Then("I see the order confirmation page")]
        public void ThenISeeTheOrderConfirmationPage()
        {
            Assert.That(checkoutCompletePage.IsOrderConfirmationDisplayed(), Is.True,
                "Expected order confirmation header to be displayed");
        }

        [Then("I should see an error message {string}")]
        public void ThenIShouldSeeAnErrorMessage(string errorMsg)
        {
            Assert.That(checkoutStepOnePage.RetrieveErrorMsg(), Is.EqualTo(errorMsg));
        }

        [Then("the cart badge should display {string}")]
        public void ThenTheCartBadgeShouldDisplay(string batchCount)
        {
            Assert.That(headerPage.RetrieveCartBadgeCount(), Is.EqualTo(batchCount));
        }

        [When("I click on the cancel button in checkout one page")]
        public void WhenIClickOnTheCheckoutOneCancelButton()
        {
            checkoutStepOnePage.ClickOnCancelBtn();
        }

        [When("I click on the cancel button in checkout two page")]
        public void WhenIClickOnTheCheckoutTwoCancelButton()
        {
            checkoutStepTwoPage.ClickOnCancelBtn();
        }

        [When("I click on the back home button")]
        public void WhenIClickOnTheBackHomeButton()
        {
            checkoutCompletePage.ClickOnBackHomeBtn();
        }

        [When("I dismiss the error message")]
        public void WhenIDismissTheErrorMessage()
        {
            checkoutStepOnePage.DismissErrorMessage();
        }

        [Then("the error message should not be visible")]
        public void ThenTheErrorMessageShouldNotBeVisible()
        {
            Assert.That(checkoutStepOnePage.IsErrorMessageVisible(), Is.False,
                "Expected error message to not be visible after dismissal");
        }
    }
}
