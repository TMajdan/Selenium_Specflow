using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Task_TMajadan.SeleniumFramework.Support;
using Task_TMajdan.SeleniumFramework.Support.Enums;

namespace Task_TMajdan.SeleniumFramework.Support
{
    public static class ActionsUtils
    {

        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public static void SendKeys(this IWebDriver driver, IWebElement inputElement, string value, int waitTimeout = 5)
        {
            ClearInputValue(inputElement);
            inputElement.SendKeys(value);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeout));

            try
            {
                wait.Until(x => inputElement.GetAttribute("value") == value);
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Input value was not set to: " + value);
            }
        }

        public static void SendEnumKeys(this IWebDriver driver, IWebElement inputElement, Enum value, int waitTimeout = 5)
        {
            SendKeys(driver, inputElement, value.ToString(), waitTimeout);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeout));

            try
            {
                wait.Until(x => inputElement.GetAttribute("value") == value.ToString());
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Input value was not set to: " + value);
            }
        }

        public static void ClearInputValue(IWebElement inputElement)
        {
            inputElement.Clear();
        }

        public static void SelectCheckbox(IWebElement checkboxElement)
        {
            if (!GetCheckboxStatus(checkboxElement))
            {
                ClickElement(checkboxElement);
            }
        }

        public static bool GetCheckboxStatus(IWebElement checkboxElement)
        {
            return checkboxElement.Selected;
        }

        public static List<IWebElement> GetTableCells(IWebElement tableElement)
        {
            return tableElement.FindElements(By.TagName("td")).ToList();
        }

        public static List<IWebElement> FindChildElements(IWebElement parentElement, IWebDriver driver, By by, int timeout = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            List<IWebElement> childElements = new List<IWebElement>();

            wait.Until(ExpectedConditions.ElementExists(by));
            childElements.AddRange(parentElement.FindElements(by));

            return childElements;
        }

        public static void SelectElementFromList(IWebDriver driver, IWebElement searchInput, Category value)
        {
            ClickElement(searchInput);
            driver.SendEnumKeys(searchInput, value);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var searchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("DetailFormcategories-input-search-list")));

            ClickElement(searchResult);
        }

        public static void SelectOptionsFromPopup(IWebDriver driver, IWebElement searchInput, List<Category> values)
        {
            By popupSearchLocation = By.XPath("//div[contains(@id, 'input-search') and contains(@class, 'popup-default')]");
            By popupListLocation = By.XPath(".//div[contains(@class, 'option-cell')]");
            By popupInputBody = By.XPath(".//div[@id='DetailFormcategories-input-search-text']//input");

            ClickElement(searchInput);

            WaitUtils.WaitForElementToBeVisible(driver, popupSearchLocation);
            WaitUtils.WaitForElementToBeVisible(driver, popupListLocation);

            IWebElement currentInputElement = driver.FindElement(popupInputBody);

            foreach (var value in values)
            {
                if (ElementsUtils.IsElementPresent(currentInputElement))
                {
                    SelectElementFromList(driver, currentInputElement, value);
                }
                else
                {
                    SelectElementFromList(driver, driver.FindElement(popupSearchLocation), value);
                }
            }

            WaitUtils.WaitForElementToBeInvisible(driver, popupSearchLocation);
            WaitUtils.WaitForElementToBeInvisible(driver, popupListLocation);
        }

    }
}