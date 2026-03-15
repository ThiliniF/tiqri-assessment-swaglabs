Feature: Login Flow

As a standard user
I want to log in to Swag Labs
So that I can access the inventory

Scenario: Successful login with valid credentials
    Given I am on the login page
    When I login as a standard user
    Then I should be on the inventory page
