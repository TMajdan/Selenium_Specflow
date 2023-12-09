using Task_TMajdan.SeleniumFramework.Support.Enums;

namespace Task_TMajdan.SeleniumFramework
{
    public class MainMenuPaths
    {
        public MainMenuTabs MainMenuTab { get; set; }
        public SubmenuTabs? SubmenuTab { get; set; }

        public MainMenuPaths(MainMenuTabs mainMenuTab, SubmenuTabs? submenuTab = null)
        {
            MainMenuTab = mainMenuTab;
            SubmenuTab = submenuTab;
        }
    }

}