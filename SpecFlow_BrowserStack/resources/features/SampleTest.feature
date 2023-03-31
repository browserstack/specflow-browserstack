@sample-test
Feature: Sample
	Scenario Outline: Can add product to cart
		Given I navigate to website
		Then I should see title StackDemo
		Then I add product to cart
		When I check if cart is opened
		Then I should see same product in cart
