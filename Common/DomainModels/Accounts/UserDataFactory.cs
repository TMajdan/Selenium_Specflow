namespace Task_TMajdan.Src.DomainModels.Accounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Task_TMajdan.Src.DomainModels.Users;

    internal class UserDataFactory
    {
        private static readonly Random random = new Random();

        public static UserData GetRandomUser()
        {
            List<UserData> users = UsersLists.Users;

            if (users?.Count == 0)
            {
                throw new InvalidOperationException("The list of users is empty.");
            }

            int randomIndex = random.Next(users.Count);

            return users[randomIndex];
        }

        public static UserData GetUserByName(string username)
        {
            List<UserData> users = UsersLists.Users;

            if (users == null || users.Count == 0)
            {
                throw new InvalidOperationException("The list of users is empty.");
            }

            return users.FirstOrDefault(user => user.FirstName == username);
        }
    }
}