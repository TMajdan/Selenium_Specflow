using OpenQA.Selenium;
using RestSharp;
using Task_TMajdan.Delivery.Model;
using Task_TMajdan.Src.Exceptions;
using TMajdanQATestTask.Src.Delivery;

namespace Task_TMajdan.Src.Delivery
{
    internal class UserLoginHandler
    {
        public static bool TryLoginWithApi(IWebDriver _driver, string baseUrl, string apiUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            _driver.Manage().Cookies.DeleteAllCookies();
            
            LoginRequestData loginRequestData = LoginRequestData.MockLogin(
                username: AppConfig.GetAppSetting("username"),
                password: AppConfig.GetAppSetting("password"),
                language: AppConfig.GetAppSetting("language"));

            var client = new RestClient(baseUrl);
            var request = new RestRequest(apiUrl, Method.Post);

            request.AddHeader(KnownHeaders.ContentType, "application/json");
            request.AddJsonBody(loginRequestData.GetRequestFieldsToDictionary());

            RestResponse response = DeliveryRestHandler.ExecuteRequest(() => client.ExecutePostAsync(request));

            if (!response.IsSuccessful || response.Content is null)
            {
                string errorMessage = $"Response returned with errors:" +
                    $"\n    url: {response.ResponseUri}" +
                    $"\n    status code: {response.StatusCode}" +
                    $"\n    message: {response.ErrorMessage}" +
                    $"\n    body: {response.Content}";
                throw new RestClientException(errorMessage);
            }

            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);

            if (jsonResponse?.ContainsKey("json_session_id") ?? false)
            {
                string? jsonSessionId = jsonResponse["json_session_id"];

                if (jsonSessionId != null)
                {
                    var sessionCookie = new OpenQA.Selenium.Cookie("PHPSESSID", jsonSessionId);
        
                    _driver.Manage().Cookies.AddCookie(sessionCookie);
                    
                    _driver.Navigate().GoToUrl(baseUrl);
                }
            }

            return true;
        }

    }
}