using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using Task_TMajadan.PageObjects.ReportsPage;
using Task_TMajdan.Src.DomainModels.Accounts;
using Task_TMajdan.Src.DomainModels.Users;

namespace Task_TMajadan.StepDefinitions
{
    [Binding]
    internal class ReportStepDefinitions
    {
        private readonly IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private ReportsPage? _reportsPage;
        private ReportPage? _reportPage;

        public ReportStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _reportsPage = new ReportsPage(_driver);
            _reportPage = new ReportPage(_driver);
        }

        [When(@"User Search '(.*)' report and open it")]
        public void WhenUserSearchAndOpenReport(string reportName)
        {
            _reportsPage.SearchAndOpenReport(reportName);
        }

        [When(@"User run report")]
        public void WhenUserRunReport()
        {
            _reportPage.RunReport();
        }

        [When(@"User Verify that report contains table with rows/columns and and text '(.*)'")]
        public void WhenVerifyThatReportContainsTableWithRowsColumnsAndAndText(string columnNameItemText)
        {
            _reportsPage.VerifyReportData(columnNameItemText);
        }
    }
}