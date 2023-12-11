Feature: demo.1crmcloud_Scenarios

Testing https://demo.1crmcloud.com/ page

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

#@Browser:Firefox
#@Browser:Edge
@Browser:Chrome
Scenario: Scenario 2 - Run report (Project Profitability)
	# Summary: This scenario verifies the report 'Project Profitability' on the 1CRM demo page.

	Given User is logged in and on the main page
	When User navigates to 'Reports And Settings' menu item and 'Reports' submenu item
	And User Search 'Project Profitability' report and open it
	When User run report
	Then User Verify that report contains table with rows/columns and and text '1CRM Systems Corp.'

#@Browser:Firefox
#@Browser:Edge
@Browser:Chrome
Scenario: Scenario 3 - Remove events from activity log
	# Summary: This scenario verifies the process of removing events from activity log on the 1CRM demo page.

	Given User is logged in and on the main page
	When User navigates to 'Reports And Settings' menu item and 'ActivityLog' submenu item
	Then User selects '3' rows in the Activity Log table
	When User click Action then 'Delete' button
	Then User should not see deleted rows in the Activity Log table
