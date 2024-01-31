Feature: AddItemToTheCart
	Simple test for adding item to the cart

@id12312
Scenario Outline: Add Item To The Cart
	Given logged in to the site with username '<userName>' and password '<password>'
	And we have a table
	| FirstValue  | SecondValue  |
	| "Test1"     | "Test2"      |

	When item added to the cart
	Then the item in the cart
	And item added to the cart
	Then the item in the cart
	And item added to the cart
	When item added to the cart

	Examples: 
	| userName      | password     |
	| standard_user | secret_sauce |
	| problem_user  | secret_sauce |
