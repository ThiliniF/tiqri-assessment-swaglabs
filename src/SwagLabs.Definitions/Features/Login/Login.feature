Feature: login

As a standard user
I want to log in to Swag Labs
So that I can access the inventory

Scenario: Successful login with valid credentials
    Given I am on the login page
    When I login with username "standard_user" and password "secret_sauce"
    Then I should be on the inventory page
