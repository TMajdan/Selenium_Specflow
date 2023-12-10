Feature: Verify test page

Search in the youtube

@Browser:Chrome
Scenario: Test Scenario
	Given User open the browser
	When User navigates to 'Sales And Marketing' menu item and 'Contacts' submenu item
	When User click 'New contact' from 'Contacts' page
	When User enters new random contact details

