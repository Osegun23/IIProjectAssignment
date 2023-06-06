Feature: Iteration

Iterate through all header items in the top navigation bar

@tag1
Scenario: Iteration
	Given I navigate to "https://www.ii.co.uk/"
	When I accept the cookie settings
	Then The company name should be on Home Page
	And I Iterate over the First Section
	And I Iterate over Second Section
	And i Iterate over the Third Section


	