using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Task_TMajadan.SeleniumFramework.Support;
using Task_TMajdan.SeleniumFramework.Support.Enums;

namespace Task_TMajdan.SeleniumFramework.Support
{
    internal static class ActionsUtils
    {
        private const int DefaultWaitTimeout = 5;

        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public static void SendKeys(this IWebDriver driver, IWebElement inputElement, string value, int waitTimeout = DefaultWaitTimeout)
        {
            ClearInputValue(inputElement);
            inputElement.SendKeys(value);
            WaitUtils.WaitUntilAttributeEquals(driver, inputElement, "value", value, waitTimeout);
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

        public static void SelectOptionsFromSearchListPopup(IWebDriver driver, IWebElement searchInput, List<Category> values)
        {
            By popupSearchLocation = By.XPath("//div[contains(@id, 'input-search') and contains(@class, 'popup-default')]");
            By popupInputBody = By.XPath(".//div[@id='DetailFormcategories-input-search-text']//input");
            By newPopupInput = By.XPath("//*[@id='DetailFormcategories-input']");

            ClickElement(searchInput);
            IWebElement currentInputElement = driver.FindElement(popupInputBody);

            foreach (var value in values)
            {
                if (!ElementsUtils.IsElementPresent(currentInputElement))
                {
                    WaitUtils.WaitForElementToBeVisible(driver, newPopupInput);
                    ClickElement(driver.FindElement(newPopupInput));
                }
                SelectElementSearchablePopupFromList(driver, currentInputElement, value.ToString());
            }

            WaitUtils.WaitForElementToBeInvisible(driver, popupSearchLocation);
        }

        public static void SelectOptionFromListPopup(IWebDriver driver, IWebElement element, Role value)
        {
            SelectElementFromPopupList(driver, element, value.ToString());
        }

        public static void SelectElementSearchablePopupFromList(IWebDriver driver, IWebElement searchInput, string value)
        {
            
            driver.SendKeys(searchInput, value);

            IWebElement searchResult = driver.FindElement(By.Id("DetailFormcategories-input-search-list"));
            ClickElement(searchResult);
        }

        public static void SelectElementFromPopupList(IWebDriver driver, IWebElement searchInput, string value)
        {
            ClickElement(searchInput);
            By dropdownSelector = By.Id("DetailFormbusiness_role-input-popup");
            By listItemSelector = By.XPath(".//div[contains(@class, 'option-cell')]");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var dropdown = wait.Until(ExpectedConditions.ElementIsVisible(dropdownSelector));
            var listItems = dropdown.FindElements(listItemSelector);

            List<IWebElement> matchingItems = listItems
                .Where(item => item.Text == value.ToString())
                .ToList();

            if (matchingItems.Count > 0)
            {
                ClickElement(matchingItems.First());
            }
            else
            {
                throw new NoSuchElementException($"Element with value '{value}' not found in the list.");
            }
        }
    }
}