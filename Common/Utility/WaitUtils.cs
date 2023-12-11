using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Task_TMajadan.Common.Driver;

namespace Task_TMajdan.SeleniumFramework
{
    internal class WaitUtils
    {
        public static void WaitForUrlContains(IWebDriver driver, string partialUrl)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.MediumTimeout));
            wait.Until(ExpectedConditions.UrlContains(partialUrl));
        }

        public static void WaitForLoaderToDisappear(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.MediumTimeout));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("ajaxStatusDiv")));
        }

        public static void WaitForElementToBeVisible(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.LongTimeout));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.MediumTimeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, IWebElement element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.MediumTimeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForElementToBeSelected(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.MediumTimeout));
            wait.Until(ExpectedConditions.ElementToBeSelected(locator));
        }

        public static void WaitForElementToBeInvisible(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.MediumTimeout));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void WaitUntilAttributeEquals(IWebDriver driver, IWebElement element, string attributeName, string expectedValue, int waitTimeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeout));

            try
            {
                wait.Until(x => element.GetAttribute(attributeName) == expectedValue);
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Attribute '{attributeName}' was not set to: {expectedValue}");
            }
        }
    }
}