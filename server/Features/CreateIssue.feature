Feature: Create Issue
    
    Scenario: User Creates an Issue
        Given I am on the homepage
        When I click on "Demo AB"
        Then I should see the issue form
        And I enter "Markus.olsson2006@gmail.com" as the email
        And I enter "Telefon problem" as the title
        And I select "Reklamation" from the subject dropdown
        And I enter "Min telefon startar inte" as the Message
        When I click the "Create issue" button
        Then I should see a confirmation message

       