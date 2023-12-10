using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using Task_TMajdan.Src.DomainModels.Accounts;
using Task_TMajdan.Src.DomainModels.Users;
using Task_TMajdan.Src.PageObjects.ContactsPage;

namespace Task_TMajadan.StepDefinitions
{
    [Binding]
    public class ContactsSetpDefinitions
    {
        private readonly IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private ContactFormPage? _contactsFormPage;
        private ContactsViewPage? _contactsViewPage;
        private UserData user = UserDataFactory.GetRandomUser();

        public ContactsSetpDefinitions(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _contactsViewPage = new ContactsViewPage(_driver);
        }

        [When(@"User click 'New contact' from 'Contacts' page")]
        public void WhenUserClickNewContactFromContactsPage()
        {
            _contactsViewPage.ClickCreateNewContactButton();
            _scenarioContext.Add("user", user);
        }

        [When(@"User enters new random contact details")]
        public void WhenUserEntersNewContactDetails()
        {
            _contactsFormPage = new ContactFormPage(_driver);
            var user = _scenarioContext.Get<UserData>("user");
            _contactsFormPage.ProvideNewUserContactDetails(user);
        }

        [When(@"User click save button")]
        public void WhenUserClickSaveButton()
        {
            _contactsFormPage.SaveButton.Click();
        }

        [Then(@"User should see saved contact details")]
        public void ThenUserShouldSeeSavedContactDetails()
        {
            var user = _scenarioContext.Get<UserData>("user");
            var contactViewPage = new ContactViewPage(_driver);
            contactViewPage.VerifySummarySection(user);
            contactViewPage.VerifyBusinessRoleSection(user);
        }
    }
}