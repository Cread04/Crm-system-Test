Feature: Registeracomapny
    
    Scenario: Register a company
        Given i am on the homepage
        When i click on register 
        Then i should see the register form
        And i enter "Markus.olsson2006@gmail.com" as the email
        And i enter "abc123" as the password
        And i enter "Markus" as the username
        And i enter "Heavy" as the company name
        When i click the Skapakonto button
        