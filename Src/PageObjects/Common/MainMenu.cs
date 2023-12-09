using OpenQA.Selenium;
using Task_TMajdan.SeleniumFramework;
using Task_TMajdan.SeleniumFramework.Support;
using Task_TMajdan.SeleniumFramework.Support.Enums;

namespace Task_TMajdan.Src.PageObjects.MainMenu
{
    public class MainMenu : AbstractBasePage
    {
        private readonly By _todaysActivities = By.Id("grouptab-0");
        private readonly By _salesAndMarketing = By.Id("grouptab-1");
        private readonly By _orderManagement = By.Id("grouptab-2");
        private readonly By _projectManagement = By.Id("grouptab-3");
        private readonly By _customerService = By.Id("grouptab-4");
        private readonly By _reportsAndSettings = By.Id("grouptab-5");

        private readonly By _contactsSubMenuElementLocator = By.XPath("//a[@class='menu-tab-sub-list' and text()=' Contacts']");
        private readonly By _reportsSubMenuElementLocator = By.XPath("//a[@class='menu-tab-sub-list' and text()=' Reports']");
        private readonly By _activityLogsSubMenuElementLocator = By.XPath("//a[@class='menu-tab-sub-list' and text()=' Activity Log']");

        public MainMenu(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo(MainMenuPaths menuPath)
        {
            By tabLocator;

            switch (menuPath.MainMenuTab)
            {
                case MainMenuTabs.TodaysActivities:
                    tabLocator = _todaysActivities;
                    break;
                case MainMenuTabs.SalesAndMarketing:
                    tabLocator = _salesAndMarketing;
                    break;
                case MainMenuTabs.OrderManagement:
                    tabLocator = _orderManagement;
                    break;
                case MainMenuTabs.ProjectManagement:
                    tabLocator = _projectManagement;
                    break;
                case MainMenuTabs.CustomerService:
                    tabLocator = _customerService;
                    break;
                case MainMenuTabs.ReportsAndSettings:
                    tabLocator = _reportsAndSettings;
                    break;
                default:
                    throw new NotImplementedException($"'{menuPath.MainMenuTab}' option not supported");
            }

            WaitUtils.WaitForElementToBeClickable(_driver, tabLocator);
            ActionsUtils.ClickElement(_driver.FindElement(tabLocator));

            WaitUtils.WaitForLoaderToDisappear(_driver);

            if (menuPath.SubmenuTab.HasValue)
            {
                NavigateToSubmenu(menuPath.SubmenuTab.Value);
            }
        }

        private void NavigateToSubmenu(SubmenuTabs submenuOption)
        {
            HandleSubmenu(submenuOption);
        }

        private void HandleSubmenu(SubmenuTabs submenuOption)
        {
            By elementLocator;

            switch (submenuOption)
            {
                case SubmenuTabs.Contacts:
                    elementLocator = _contactsSubMenuElementLocator;
                    break;
                case SubmenuTabs.Reports:
                    elementLocator = _reportsSubMenuElementLocator;
                    break;
                case SubmenuTabs.ActivityLog:
                    elementLocator = _activityLogsSubMenuElementLocator;
                    break;
                default:
                    throw new NotImplementedException($"'{submenuOption}' option not supported");
            }

            HandleSubmenuAction(elementLocator);

            WaitUtils.WaitForLoaderToDisappear(_driver);
        }

        private void HandleSubmenuAction(By elementLocator)
        {
            WaitUtils.WaitForElementToBeVisible(_driver, elementLocator);
            WaitUtils.WaitForElementToBeClickable(_driver, elementLocator);
            ActionsUtils.ClickElement(_driver.FindElement(elementLocator));
        }
    }
}