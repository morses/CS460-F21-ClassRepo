Feature: StaticContent

As a visitor to the site I would like to know which fruit this site allows me to eat.

@tag1
Scenario: Title on home page contains apples
	Given I am a visitor
	  And I am on the home page
#	When [action]
	Then I can see that Apples can be eaten
