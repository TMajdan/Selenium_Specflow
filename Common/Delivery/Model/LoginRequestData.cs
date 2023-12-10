using System.Reflection;

namespace Task_TMajdan.Delivery.Model
{
    public class LoginRequestData
    {
        private readonly int resWidth;
        private readonly int resHeight;
        private readonly string username;
        private readonly string password;
        private readonly string remember;
        private readonly string language;
        private readonly string theme;
        private readonly string loginModule;
        private readonly string loginAction;
        private readonly string loginRecord;
        private readonly string loginLayout;
        private readonly string mobile;
        private readonly int gmto;

        public LoginRequestData(
            string username,
            string password,
            string language)
        {
            this.resWidth = 1920;
            this.resHeight = 1080;
            this.username = username;
            this.password = password;
            this.remember = "";
            this.language = language;
            this.theme = "Flex";
            this.loginModule = "";
            this.loginAction = "";
            this.loginRecord = "";
            this.loginLayout = "";
            this.mobile = "";
            this.gmto = -60;
        }

        public static LoginRequestData MockLogin(
            // You can customize this method to generate a mock login request
            string username,
            string password,
            string language)
               => new LoginRequestData(
                    username: username,
                    password: password,
                    language: language);

        public Dictionary<string, string> GetRequestFieldsToDictionary()
        {
            return GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .ToDictionary(o => o.Name, o => o.GetValue(this)?.ToString() ?? string.Empty);
        }
    }
}