namespace Task_TMajdan.Src.DomainModels.Users
{
    using System.Collections.Generic;
    using Task_TMajdan.SeleniumFramework.Support.Enums;
    using Task_TMajdan.Src.Support;

    public static class UsersLists
    {
        public static List<UserData> Users = new List<UserData>()
        {
            new UserData
            {
                FirstName = "TOMASZ",
                LastName = "M",
                Email = "test@test.test",
                Phone = TestDataUtils.GenerateRandomNumber(999999999).ToString(),
                Role = Role.CEO,
                Category = new List<Category> { Category.Customers, Category.Suppliers },
            },

            new UserData
            {
                FirstName = "Anna",
                LastName = "Kowalska",
                Email = "anna.kowalska@test.test",
                Phone = TestDataUtils.GenerateRandomNumber(999999999).ToString(),
                Role = Role.Admin,
                Category = new List<Category> { Category.Customers, Category.Suppliers },
            }
        };
    }
}