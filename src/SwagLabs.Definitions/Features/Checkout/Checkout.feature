Feature: Checkout Flow

As a standard user
I want to complete a purchase on Swag Labs
So that I can successfully order products

Background: 
    Given I am on the login page
    When I login with username "standard_user" and password "secret_sauce"
    Then I should be on the inventory page


@e2e @happy-path
Scenario: Checkout information form is displayed after adding a product
    Given I am on the "Products" page
    When I click on "Sauce Labs Backpack"
    And I add it to the cart
    And I navigate to the cart
    And I click checkout button
    Then I should see the page header "Checkout: Your Information"
    And the following fields should be visible
      | First Name      |
      | Last Name       |
      | Zip/Postal Code |
    And a "Continue" button should be visible
    And a "Cancel" button should be visible
