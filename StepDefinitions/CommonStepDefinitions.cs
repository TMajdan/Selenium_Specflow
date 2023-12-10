using OpenQA.Selenium;
using Task_TMajdan.SeleniumFramework;
using Task_TMajdan.SeleniumFramework.Support.Enums;
using Task_TMajdan.Src.PageObjects.MainMenu;

namespace Task_TMajdan.StepDefinitions
{
    [Binding]
    internal class CommonStepDefinitions
    {
        private readonly IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private readonly MainMenu _mainMenu;

        public CommonStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
            _mainMenu = new MainMenu(_driver);
        }

        [When(@"User navigates to '(.*)' menu item(?: and '(.*)' submenu item)?")]
        public void NavigateToMenuItem(MainMenuTabs mainMenuTab, SubmenuTabs? submenuOption)
        {
            MainMenuPaths menuPath = new MainMenuPaths(mainMenuTab, submenuOption);

            _mainMenu.NavigateTo(menuPath);
        }

        [Given(@"User is logged in and on the main page")]
        public void UserIsLoggedInAndOnTheMainPage()
        {
            return;
        }
    }
}