Feature: InClassExamples

A short summary of the feature


Scenario: Search for a show on IMDB
	Given I am on the Search page
	When I search for a TV show
	Then I will see a list of shows in the results

Scenario Outline: Search for a multiple shows on IMDB
	Given I am on the Search page
	When I search for a TV show called <name>
	Then I will see a list of shows in the results that contain the show <name>
	Examples: 
	| name         |
	| Pulp Fiction |
	| Star Trek    |
