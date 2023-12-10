using NUnit.Framework;
using OpenQA.Selenium;

namespace Task_TMajdan.SeleniumFramework.Support
{
    public static class AssertionsUtils
    {
        public static void AssertIsElementDisplayed(IWebElement element)
        {
            Assert.IsTrue(element.Displayed, $"Element {element} is not displayed");
        }
    }
}