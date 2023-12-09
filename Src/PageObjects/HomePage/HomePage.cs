using OpenQA.Selenium;
using Task_TMajdan.SeleniumFramework;
using Task_TMajdan.Src.PageObjects;

namespace Task_TMajdan.Src
{

    public class HomePage : AbstractBasePage
    {
        private readonly By _homePageDashboards = By.Id("dashboard_columns");

        public HomePage(IWebDriver driver) : base(driver)
        {
            WaitForPageToLoad();
        }

        private void WaitForPageToLoad()
        {
            VerifyPage();
            WaitUtils.WaitForElementToBeVisible(_driver, _homePageDashboards);
        }
    }
}
