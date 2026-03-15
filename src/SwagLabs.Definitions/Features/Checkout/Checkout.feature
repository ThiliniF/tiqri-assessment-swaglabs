@e2e @happy-path
Feature: Checkout Flow

As a standard user
I want to complete a purchase on Swag Labs
So that I can successfully order products

Background: 
    Given I am on the login page
    When I login as a standard user
    Then I should be on the inventory page

Scenario: Checkout information form is displayed after adding a product
    Given I am on the "Products" page
    When I click on "Sauce Labs Backpack"
    And I add it to the cart
    And I navigate to the cart
    And I click checkout button
    Then I should see the page header "Checkout: Your Information"
    And the following fields should be visible
      | Field           |
      | First Name      |
      | Last Name       |
      | Zip/Postal Code |
    And a "Continue" button should be visible
    And a "Cancel" button should be visible

 Scenario: Successfully complete checkout step one
    Given I am on the "Products" page
    When I click on "Sauce Labs Backpack"
    And I add it to the cart
    And I navigate to the cart
    And I click checkout button
    And I enter first name "John"
    And I enter last name "Doe"
    And I enter zip code "11000"
    And I click on continue button
    Then I should be on the checkout step two page
    And I should see the page header "Checkout: Overview"

 Scenario: Add multiple items to the cart
    Given I am on the "Products" page
      When I add the following items to the cart
        | Item                    |
        | Sauce Labs Backpack     |
        | Sauce Labs Bike Light   |
        | Sauce Labs Bolt T-Shirt |
      And I navigate to the cart
      Then the cart should contain
        | Item                    |
        | Sauce Labs Backpack     |
        | Sauce Labs Bike Light   |
        | Sauce Labs Bolt T-Shirt |

 Scenario: Checkout overview displays order summary
    Given I am on the "Products" page
    When I click on "Sauce Labs Backpack"
    And I get the item price as "itemPrice"
    And I add it to the cart
    And I navigate to the cart
    And I click checkout button
    And I enter first name "John"
    And I enter last name "Doe"
    And I enter zip code "11000"
    And I click on continue button
    Then I should be on the checkout step two page
    And I should see the page header "Checkout: Overview"
    And the cart should contain
        | Item                |
        | Sauce Labs Backpack |
    And the price should display "itemPrice"
    And I should see the payment information
    And I should see the shipping information
    And I should see the item total
    And I should see the tax amount
    And the order total should be the sum of item total and tax
