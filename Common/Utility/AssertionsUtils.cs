using NUnit.Framework;
using OpenQA.Selenium;

namespace Task_TMajdan.SeleniumFramework.Support
{
    internal static class AssertionsUtils
    {
        public static void AssertIsElementDisplayed(IWebElement element)
        {
            Assert.IsTrue(element.Displayed, $"Element {element} is not displayed");
        }

        public static void AssertIsElementContains(string actualText, string expectedText)
        {
            Assert.IsTrue(actualText.Contains(expectedText), $"Expected: '{expectedText}', Actual: '{actualText}'");
        }
    }
}