Feature: AppLogin
	
@mytag
Scenario: Log in with correct credentials
	Given I go to "http://localhost:49988"
	And I click on Log in link
	And I set username with "merino@live.com"
	And I set password with "12345"
	When I click on login button
	Then I should see "KUDOS" message

Scenario: Log in using incorrect credentials
	Given I go to "http://localhost:49988"
	And I click on Log in link
	And I set username with "merino@live.com"
	And I set password with "54231"
	When I click on login button
	Then I should see "Invalid login attempt." error label
	