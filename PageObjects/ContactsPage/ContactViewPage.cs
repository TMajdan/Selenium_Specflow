using OpenQA.Selenium;
using Task_TMajadan.SeleniumFramework.Support;
using Task_TMajdan.SeleniumFramework.Support;
using Task_TMajdan.Src.DomainModels.Users;

namespace Task_TMajdan.Src.PageObjects.ContactsPage
{
    internal class ContactViewPage : AbstractBasePage
    {
        private readonly By _summarySection = By.Id("le_section__summary");
        private readonly By _businessRoleSection = By.Id("le_section_main");

        public IWebElement SummarySection => _driver.FindElement(_summarySection);
        public IWebElement BusinessRoleSection => _driver.FindElement(_businessRoleSection);

        private string summarySectionContain;
        private string businessRoleSectionContain;

        public ContactViewPage(IWebDriver driver) : base(driver)
        {
            summarySectionContain = ElementsUtils.GetInnerText(SummarySection);
            businessRoleSectionContain = ElementsUtils.GetInnerText(BusinessRoleSection);
        }

        public void VerifySummarySection(UserData user)
        {
            AssertionsUtils.AssertIsElementDisplayed(SummarySection);
            AssertionsUtils.AssertIsElementContains(summarySectionContain, user.FirstName);
            AssertionsUtils.AssertIsElementContains(summarySectionContain, user.LastName);
            AssertionsUtils.AssertIsElementContains(summarySectionContain, user.Email);
            AssertionsUtils.AssertIsElementContains(summarySectionContain, user.Phone);

            foreach (var category in user.Category)
            {
                AssertionsUtils.AssertIsElementContains(summarySectionContain, category.ToString());
            }
        }
        public void VerifyBusinessRoleSection(UserData user)
        {
            AssertionsUtils.AssertIsElementDisplayed(BusinessRoleSection);
            AssertionsUtils.AssertIsElementContains(businessRoleSectionContain, user.Role.ToString());
        }
    }
}