Feature: Login as a User
    
    Scenario: Login into the workersite
        Given I am on the  homepage
        When I click the login link
        Then I should see the Login Popup
        Then I enter "no@email.com" into the login email field
        And I enter "abc123" as the password
        When I click the "Login" button on the login page
        Then I Should see the worksite
        
         