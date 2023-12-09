using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Task_TMajdan.Src.PageObjects.ContactsPage
{
    public class ContactFormPage
    {
        private readonly By _saveButton = By.Id("DetailForm_save");
        private readonly By _salutationInput = By.Id("DetailFormsalutation-input");
        private readonly By _firstNameInput = By.Id("DetailFormfirst_name-input");
        private readonly By _lastNameInput = By.Id("DetailFormlast_name-input");
    }
}