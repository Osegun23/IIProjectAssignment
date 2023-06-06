Feature: IIHomePage

To automate how a customer would navigate to trading account

@tag1
Scenario: Validating Trading Account
	Given I navigate to "https://www.ii.co.uk/"
	When I accept the cookie settings
	Then The company name should be on Home Page
	And I look at the Top Menu i should see Services
	When I click on Services
	Then I should see the Accounts under Services drop down
	And Under the Accounts i should see Trading account
	When I click on Trading account
	Then I should see the Trading account page
	Then I should see the change in url
