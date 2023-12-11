using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Task_TMajdan.Common.Driver;
using Task_TMajdan.SeleniumFramework.Support.Enums;

namespace Task_TMajdan.SeleniumFramework.Support
{
    internal static class ActionsUtils
    {
        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public static void SendKeys(this IWebDriver driver, IWebElement inputElement, string value, int waitTimeout = Timeouts.MediumTimeout)
        {
            ClearInputValue(inputElement);
            inputElement.SendKeys(value);
            WaitUtils.WaitUntilAttributeEquals(driver, inputElement, "value", value, waitTimeout);
        }

        public static void ClearInputValue(IWebElement inputElement)
        {
            inputElement.Clear();
        }

        public static void SetCheckboxStatus(IWebElement checkbox, bool markUnmark)
        {
            if ((markUnmark && !checkbox.Selected) || (!markUnmark && checkbox.Selected))
            {
                ClickElement(checkbox);
            }
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

        public static void SelectOptionFromListPopup(IWebDriver driver, IWebElement element, string value)
        {
            SelectElementFromPopupList(driver, element, value);
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

            By dropdownSelector = By.XPath("//div[contains(@id, '-popup')]");
            By listItemSelector = By.XPath(".//div[contains(@class, 'option-cell')]");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.MediumTimeout));
            var dropdown = wait.Until(ExpectedConditions.ElementIsVisible(dropdownSelector));
            var listItems = dropdown.FindElements(listItemSelector);

            var matchingItem = listItems.FirstOrDefault(item => item.Text == value);

            if (matchingItem != null)
            {
                ClickElement(matchingItem);
                HandleBrowserAlertIfPresent(driver);
            }
            else
            {
                throw new NoSuchElementException($"Element with value '{value}' not found in the list.");
            }
        }
        private static void HandleBrowserAlertIfPresent(IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException)
            {
                // Alert not present
            }
        }

        public static void CheckForTextInTable(IWebDriver driver, string searchText)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.MediumTimeout));

            IWebElement tableBody = wait.Until(ExpectedConditions.ElementExists(By.XPath("//tbody")));
            IList<IWebElement> rows = tableBody.FindElements(By.TagName("tr"));

            if (rows.Count < 1)
            {
                throw new Exception("Table contains no rows.");
            }

            foreach (var row in rows)
            {
                IList<IWebElement> cells = row.FindElements(By.TagName("td"));

                foreach (var cell in cells)
                {
                    if (cell.Text.Contains(searchText))
                    {
                        return;
                    }
                }
            }

            throw new Exception($"Text '{searchText}' not found in the table.");
        }

        public static List<IWebElement> FindSearchableListByText(IWebDriver driver, IWebElement parentElement, string searchText, bool throwException = true)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeouts.LongTimeout));
            List<IWebElement>? elements = null;

            try
            {
                elements = wait.Until(x =>
                {
                    var searchResults = parentElement.FindElements(By.XPath($"//div[contains(@class, 'single') and contains(., '{searchText}')]"));
                    return searchResults.Any() ? searchResults.ToList() : null;
                });
            }
            catch (NotFoundException ex)
            {
                if (throwException)
                {
                    throw new NotFoundException($"Element with text '{searchText}' not found.", ex);
                }
            }

            return elements;
        }
    }
}