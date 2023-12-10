using OpenQA.Selenium;
using Task_TMajdan.SeleniumFramework;
using Task_TMajdan.SeleniumFramework.Support;

namespace Task_TMajdan.Src.PageObjects.ContactsPage
{
    public class ContactsViewPage : AbstractBasePage
    {

        private readonly By _createNewContactButton = By.XPath("//button[contains(@id, '-create')]");

        private IWebElement CreateNewContactButton => _driver.FindElement(_createNewContactButton);

        public ContactsViewPage(IWebDriver driver) : base(driver)
        {
        }

        public ContactsViewPage ClickCreateNewContactButton()
        {
            WaitUtils.WaitForElementToBeVisible(_driver, _createNewContactButton);
            WaitUtils.WaitForElementToBeClickable(_driver, _createNewContactButton);
            ActionsUtils.ClickElement(CreateNewContactButton);

            return this;
        }
    }
}