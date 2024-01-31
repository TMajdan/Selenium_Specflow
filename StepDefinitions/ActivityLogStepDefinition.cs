using OpenQA.Selenium;
using Task_TMajdan.PageObjects;

namespace Task_TMajdan.StepDefinitions
{
    [Binding]
    internal class ActivityLogStepDefinition
    {
        private readonly IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private ActivityLogPage _activityLogPage;

        public ActivityLogStepDefinition(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _activityLogPage = new ActivityLogPage(_driver);
        }

        [Then(@"User selects '(.*)' rows in the Activity Log table")]
        public void WhenUserSelectsRowsInTheActiviyLogTable(int rowsCount)
        {
            _activityLogPage.SelectCheckboxesInTableRows(rowsCount, true);
        }

        [When(@"User click Action then '(.*)' button")]
        public void WhenWhenUserClickActionThenDeleteButton(string action)
        {
            _activityLogPage.ClickActionButtonAndSelectAction(action);
        }

        [Then(@"User should not see deleted rows in the Activity Log table")]
        public void ThenUserShouldNotSeeDeletedRowsInTheActiviyLogTable()
        {
            _activityLogPage.VerifyDeletedRowsDoNotExist();
        }
    }
}