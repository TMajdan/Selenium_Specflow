using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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

        public static void SearchOnList(IWebDriver driver, IWebElement searchInput, string value)
        {
            driver.SendKeys(searchInput, value);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(text(),'" + value + "')]")));
            var searchResult = driver.FindElement(By.XPath("//li[contains(text(),'" + value + "')]"));
            ClickElement(searchResult);
        }

        public static IWebElement FindElement(IWebDriver driver, By by, int timeout = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementExists(by));
            return driver.FindElement(by);
        }

        public static void AcceptAlert(IWebDriver driver)
        {
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public static void SelectOptionFromPopup(IWebDriver driver, IWebElement searchInput, string value)
        {
            var popupLocation = By.XPath($"//div[@class='select2-result-label' and contains(text(),'{value}')]");
            var popupListLocation = By.XPath("//ul[@class='select2-results']");

            ClickElement(searchInput);
            WaitUtils.WaitForElementToBeVisible(driver, popupListLocation);

            var popListItem = FindChildElements(FindElement(driver, popupLocation), driver, popupListLocation)
                .Find(x => x.Text == value);

            ClickElement(popListItem);

            if (value == "Delete") AcceptAlert(driver);
        }
    }
}