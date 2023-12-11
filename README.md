# Demo.1crmcloud.com - Framework

## Overview

This is a C# framework for test automation using Selenium, RestSharp, and SpecFlow. The framework is designed to support web UI and API automation testing. Configuration of test data can be done by editing the `appsettings.json` file.

## Supported Browsers

- Chrome
- Firefox
- Edge

**Note**: Test automation should use the latest versions of the browsers.

## Configuration

To configure the browser for your tests, modify the `Demo1CrmScenarios.feature` file. Use one of the available values for the `@Browser` tag, for example:

```gherkin
#@Browser:Firefox
#@Browser:Edge
@Browser:Chrome
Scenario: Scenario 1 - create contact
	# Summary: This scenario verifies the process of creating a new contact on the 1CRM demo page.
```

## Report Generation

After the completion of tests, a report is generated under the `/TestResults` directory. In case any test fails, a detailed report containing a screenshot of the step where the error occurred is created.

![msedge_wJHp2Bf22A](https://github.com/TMajdan/Task_TMajdan/assets/18539842/f8b0b8f9-014f-4688-8173-1985b235ff3a)

## Getting Started

1. Clone the repository: `git clone https://github.com/TMajdan/Task_TMajdan.git`
2. Configure test data in `appsettings.json` if needed.
3. Run tests using your preferred test runner.

## Dependencies

- Selenium
- RestSharp
- SpecFlow

## Contributions

Feel free to contribute by creating issues or submitting pull requests.
