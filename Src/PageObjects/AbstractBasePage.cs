using OpenQA.Selenium;
using Task_TMajdan.SeleniumFramework;

namespace Task_TMajdan.Src.PageObjects
{
    public abstract class AbstractBasePage
    {
        protected readonly IWebDriver _driver;

        public AbstractBasePage(IWebDriver driver)
        {
            _driver = driver;
            VerifyPage();
        }

        public void VerifyPage()
        {
            WaitUtils.WaitForLoaderToDisappear(_driver);
        }
    }
}