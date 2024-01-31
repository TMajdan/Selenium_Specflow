Feature: demo.1crmcloud_Scenarios1

#@Browser:Firefox
#@Browser:Edge
@Browser:Chrome
Scenario: Scenario 1 - create contact
	# Summary: This scenario verifies the process of creating a new contact on the 1CRM demo page.

	Given User is logged in and on the main page
	When User navigates to 'Sales And Marketing' menu item and 'Contacts' submenu item
	And User click 'New contact' from 'Contacts' page
	Then User enters new random contact details
	When User click save button
	Then User should see saved contact details