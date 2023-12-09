namespace TMajdanQATestTask
{
    using System.Collections.Generic;
    using System.Threading;
    using Task_TMajdan.Src.DomainModels.Users;

    public static class Globals
    {
        private static ThreadLocal<List<UserData>> users = new ThreadLocal<List<UserData>>();

        public static List<UserData> Users
        {
            get
            {
                if (users.Value is null)
                {
                    users.Value = new ();
                }

                return users.Value;
            }
        }
    }
}
