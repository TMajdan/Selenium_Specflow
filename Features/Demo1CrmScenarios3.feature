Feature: demo.1crmcloud_Scenarios3

Testing https://demo.1crmcloud.com/ page

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
