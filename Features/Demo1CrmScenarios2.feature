Feature: demo.1crmcloud_Scenarios2

#@Browser:Firefox
#@Browser:Edge
@Browser:Chrome
Scenario: Scenario 2 - Run report (Project Profitability)
	# Summary: This scenario verifies the report 'Project Profitability' on the 1CRM demo page.

	Given User is logged in and on the main page
	When User navigates to 'Reports And Settings' menu item and 'Reports' submenu item
	And User Search 'Project Profitability' report and open it
	When User run report
	Then User Verify that report contains table with rows/columns and and text '360 Vacations'