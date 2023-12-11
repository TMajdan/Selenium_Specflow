using OpenQA.Selenium;

namespace Task_TMajdan.SeleniumFramework.Support
{
    internal static class ElementsUtils
    {
        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public static string GetInnerText(IWebElement element) => element.GetAttribute("innerText");

    }
}