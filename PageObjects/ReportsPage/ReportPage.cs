using OpenQA.Selenium;
using Task_TMajdan.SeleniumFramework;
using Task_TMajdan.SeleniumFramework.Support;
using Task_TMajdan.Src.PageObjects;

namespace Task_TMajdan.PageObjects.ReportsPage
{
    internal class ReportPage : AbstractBasePage
    {
        private readonly By _runReportButton = By.XPath("//button[@type='submit']//span[text()='Run Report']");
        private IWebElement RunReportButton => _driver.FindElement(By.XPath("//button[@type='submit']//span[text()='Run Report']"));

        public ReportPage(IWebDriver driver) : base(driver)
        {
        }

        public void RunReport()
        {
            WaitUtils.WaitForElementToBeVisible(_driver, _runReportButton);
            ActionsUtils.ClickElement(RunReportButton);
        }

    }
}