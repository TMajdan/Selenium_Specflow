using Microsoft.Extensions.Configuration;

internal class AppConfig
{
    private static IConfigurationRoot _configuration;

    static AppConfig()
    {
        try
        {
            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var projectDirectory = baseDirectory.Replace(Path.Combine("bin","Debug","net6.0"), "");

            var builder = new ConfigurationBuilder()
                .SetBasePath(projectDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during configuration loading: {ex.Message}");
            throw;
        }
    }
    public static string GetAppSetting(string key)
    {
        try
        {
            return _configuration["AppSettings:" + key];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during configuration retrieval: {ex.Message}");
            throw;
        }
    }
}