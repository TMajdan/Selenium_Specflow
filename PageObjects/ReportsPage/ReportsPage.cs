using OpenQA.Selenium;
using Task_TMajdan.SeleniumFramework;
using Task_TMajdan.SeleniumFramework.Support;
using Task_TMajdan.Src.PageObjects;

namespace Task_TMajadan.PageObjects.ReportsPage
{
    internal class ReportsPage : AbstractBasePage
    {
        private readonly By _reportsPageTitle = By.XPath("//span[normalize-space()='Reports']");
        private readonly By _reportSearchField = By.Id("filter_text");
        private readonly By _table = By.XPath("//table");
        private IWebElement ReportSearchField => _driver.FindElement(_reportSearchField);

        public ReportsPage(IWebDriver driver) : base(driver)
        {
            WaitForPageToLoad();
        }

        private void WaitForPageToLoad()
        {
            VerifyPage();
            WaitUtils.WaitForElementToBeVisible(_driver, _reportsPageTitle);
            WaitUtils.WaitForElementToBeVisible(_driver, _reportSearchField);
        }

        public void SearchAndOpenReport(string reportName)
        {
            
            ActionsUtils.SendKeys(_driver, ReportSearchField, reportName);
            var retrievedCell = ActionsUtils.FindSearchableListByText(_driver, ReportSearchField, reportName, throwException: true);
            
            if (retrievedCell != null && retrievedCell.Count > 0)
            {
                
                ActionsUtils.ClickElement(retrievedCell[0]);
            }
            else
            {
                throw new NotFoundException($"No cells found for report: {reportName}");
            }
        }

        public void VerifyReportData(string reportPageColumItemName)
        {
            WaitUtils.WaitForElementToBeVisible(_driver, _table);
            ActionsUtils.CheckForTextInTable(_driver, reportPageColumItemName);
        }

    }
}
