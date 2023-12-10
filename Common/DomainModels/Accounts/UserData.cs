using Task_TMajdan.SeleniumFramework.Support.Enums;

namespace Task_TMajdan.Src.DomainModels.Users
{
    /*
     * IMPORTANT: All new properties have to be null by default in this pojo class.
     */
    internal class UserData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Salutations { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<Category> Category { get; set; }

        public Role Role { get; set; }

    }
}