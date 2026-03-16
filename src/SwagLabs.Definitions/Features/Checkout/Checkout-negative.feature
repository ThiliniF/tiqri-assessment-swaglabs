@e2e @negative
Feature: Checkout Negative Flow

As a standard user
I want to complete a purchase on Swag Labs with invalid data
So that I can validate the error messages

Background: 
    Given I am on the login page
    When I login as a standard user
    Then I should be on the inventory page

Scenario: Checkout Step one error - missing first name
    Scenario Outline: Checkout Step One error - missing required field
      Given I am on the "Products" page
      When I click on "Sauce Labs Backpack"
      And I add it to the cart
      And I navigate to the cart
      And I click checkout button
      And I enter first name "<firstName>"
      And I enter last name "<lastName>"
      And I enter zip code "<zipCode>"
      And I click on continue button
      Then I should see an error message containing "<errorMessage>"

      Examples:
        | firstName | lastName | zipCode | errorMessage            |
        |           | Doe      |   11000 | Error: First Name is required  |
        | John      |          |   11000 | Error: Last Name is required   |
        | John      | Doe      |         | Error: Postal Code is required |
        |           |          |         | Error: First Name is required  |