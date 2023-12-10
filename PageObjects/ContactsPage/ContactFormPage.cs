using OpenQA.Selenium;
using Task_TMajdan.SeleniumFramework;
using Task_TMajdan.SeleniumFramework.Support;
using Task_TMajdan.Src.DomainModels.Users;

namespace Task_TMajdan.Src.PageObjects.ContactsPage
{
    internal class ContactFormPage : AbstractBasePage
    {
        private readonly By _saveButton = By.Id("DetailForm_save");
        private readonly By _firstNameInput = By.Id("DetailFormfirst_name-input");
        private readonly By _lastNameInput = By.Id("DetailFormlast_name-input");
        private readonly By _emailInput = By.Id("DetailFormemail1-input");
        private readonly By _phoneInput = By.Id("DetailFormphone_work-input");
        private readonly By _categoryDropdown = By.Id("DetailFormcategories-input");
        private readonly By _businessDropdown = By.Id("DetailFormbusiness_role-input");

        public IWebElement SaveButton => _driver.FindElement(_saveButton);
        public IWebElement FirstNameInput => _driver.FindElement(_firstNameInput);
        public IWebElement LastNameInput => _driver.FindElement(_lastNameInput);
        public IWebElement EmailInput => _driver.FindElement(_emailInput);
        public IWebElement PhoneInput => _driver.FindElement(_phoneInput);
        public IWebElement CategoryDropdown => _driver.FindElement(_categoryDropdown);
        public IWebElement BusinessDropdown => _driver.FindElement(_businessDropdown);

        public ContactFormPage(IWebDriver driver) : base(driver)
        {
            WaitForPageToLoad();
        }

        private void WaitForPageToLoad()
        {
            VerifyPage();

            var elementsToWaitFor = new[]
            {
                _saveButton, _firstNameInput, _lastNameInput,
                _emailInput, _phoneInput, _categoryDropdown, _businessDropdown
            };

            foreach (var element in elementsToWaitFor)
            {
                WaitUtils.WaitForElementToBeVisible(_driver, element);
                AssertionsUtils.AssertIsElementDisplayed(_driver.FindElement(element));
            }
        }

        public void ProvideNewUserContactDetails(UserData user)
        {
            ProvideFirstAndLastName(user);
            ProvideEmailAndPhone(user);
            SetMultipleCategoryFromPopupMenu(user);
            SetBusinessRole(user);
        }

        public void ProvideFirstAndLastName(UserData user)
        {
            ActionsUtils.SendKeys(_driver, FirstNameInput, user.FirstName);
            ActionsUtils.SendKeys(_driver, LastNameInput, user.LastName);
        }

        public void ProvideEmailAndPhone(UserData user)
        {
            ActionsUtils.SendKeys(_driver, EmailInput, user.Email);
            ActionsUtils.SendKeys(_driver, PhoneInput, user.Phone);
        }

        public void SetMultipleCategoryFromPopupMenu(UserData user)
        {
            ActionsUtils.SelectOptionsFromSearchListPopup(_driver, CategoryDropdown, user.Category);
        }

        public void SetBusinessRole(UserData user)
        {
            ActionsUtils.SelectOptionFromListPopup(_driver, BusinessDropdown, user.Role);
        }

    }
}