@search
Feature: Fast Search
	In order to buy mobile phone
	As a user
	I want to have ability to search mobile phone by mark in fast search


Scenario Outline: User found mobile phone by mark
	Given I am on main page
	And fast search field is available 
	And fast search field is empty
	When i send text <mark> in search field
	Then search frame is displayed
	And the first 10 devises is <mark>

	Examples: 
	| mark    |
	| iPhone  |
	| Samsung |