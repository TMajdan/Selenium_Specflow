using OpenQA.Selenium;

namespace Task_TMajadan.SeleniumFramework.Support
{
    public static class ElementsUtils
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