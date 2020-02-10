Feature: SearchWolverine
	As a Wolverine fan, I want to search X-Men on Marvel website so that I can view the characters

@X-Men
Scenario: Search Wolverine
	Given I am on the 'explore' page 
	When I search for 'Wolverine'
	Then I can view the character details
