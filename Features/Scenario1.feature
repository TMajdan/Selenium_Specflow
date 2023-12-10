Feature: demo.1crmcloud_Scenarios

Testing https://demo.1crmcloud.com/ page

@Browser:Chrome
Scenario: Scenario 1 - create contact
	# Summary: This scenario verifies the process of creating a new contact on the 1CRM demo page.

	Given User is logged in and on the main page
	When User navigates to 'Sales And Marketing' menu item and 'Contacts' submenu item
	When User click 'New contact' from 'Contacts' page
	When User enters new random contact details
	When User click save button
	Then User should see saved contact details

