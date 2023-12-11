using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Task_TMajdan.SeleniumFramework;
using Task_TMajdan.SeleniumFramework.Support;
using Task_TMajdan.Src.PageObjects;

namespace Task_TMajdan.PageObjects
{
    internal class ActivityLogPage : AbstractBasePage
    {
        private readonly By _activityLogTableRows = By.XPath("//tr[contains(@class, 'listViewRow')]");
        private readonly By _activityLogActionButton = By.XPath("//button[contains(@id, 'ActionButtonHead')]");

        private List<List<string>> _tableDataBeforeAction;

        public ActivityLogPage(IWebDriver driver) : base(driver)
        {
            WaitForPageToLoad();
        }

        public void WaitForPageToLoad()
        {
            WaitUtils.WaitForElementToBeVisible(_driver, _activityLogActionButton);
            WaitUtils.WaitForElementToBeVisible(_driver, _activityLogTableRows);
        }

        public void SelectCheckboxesInTableRows(int rowsAmount, bool mark)
        {
            IWebElement tableElement = _driver.FindElement(_activityLogTableRows);

            _tableDataBeforeAction = GetTableData(tableElement);

            IList<IWebElement> rowsInTable = tableElement.FindElements(_activityLogTableRows);

            foreach (int rowNumber in Enumerable.Range(1, rowsAmount))
            {
                if (rowNumber >= 1 && rowNumber <= rowsInTable.Count)
                {
                    IWebElement checkboxCell = rowsInTable[rowNumber - 1];
                    ActionsUtils.SetCheckboxStatus(checkboxCell, mark);
                }
            }
        }

        public void ClickActionButtonAndSelectAction(string action)
        {
            IWebElement actionButton = _driver.FindElement(_activityLogActionButton);

            ActionsUtils.SelectOptionFromListPopup(_driver, actionButton, action);
        }

        public void VerifyDeletedRowsDoNotExist()
        {
            IWebElement tableElement = _driver.FindElement(_activityLogTableRows);

            List<List<string>> tableDataAfterAction = GetTableData(tableElement);

            foreach (var rowBeforeAction in _tableDataBeforeAction)
            {
                if (tableDataAfterAction.Contains(rowBeforeAction))
                {
                    throw new Exception($"Row {string.Join(", ", rowBeforeAction)} was deleted but still exists in the table.");
                }
            }
        }

        private List<List<string>> GetTableData(IWebElement tableElement)
        {
            List<List<string>> tableData = new List<List<string>>();
            IList<IWebElement> rows = tableElement.FindElements(_activityLogTableRows);

            foreach (var row in rows)
            {
                try
                {
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                    List<string> rowData = new List<string>();

                    foreach (var cell in cells)
                    {
                        rowData.Add(cell.Text);
                    }

                    tableData.Add(rowData);
                }
                catch (StaleElementReferenceException)
                {
                    // Ignore
                }
            }
            return tableData;
        }
    }
}