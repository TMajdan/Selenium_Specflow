using OpenQA.Selenium;

namespace Task_TMajadan.SeleniumFramework.Support
{
    public class ElementsUtils
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
    }
}