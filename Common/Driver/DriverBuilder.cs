using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumFramework.Src.Support.Internal;

namespace Task_TMajdan.SeleniumFramework
{
    internal class DriverBuilder
    {
        private static readonly ThreadLocal<IWebDriver> Driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver SetupChromeDriver()
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");

            // Add any additional options if needed

            return new ChromeDriver(chromeDriverService, chromeOptions);
        }

        public static IWebDriver SetupEdgeDriver()
        {
            EdgeDriverService edgeDriverService = EdgeDriverService.CreateDefaultService();
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--start-maximized");

            // Add any additional options if needed

            return new EdgeDriver(edgeDriverService, edgeOptions);
        }

        public static IWebDriver SetupFirefoxDriver()
        {
            FirefoxDriverService firefoxDriver = FirefoxDriverService.CreateDefaultService();
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--start-maximized");

            // Add any additional options if needed

            return new FirefoxDriver(firefoxDriver, firefoxOptions);
        }

        public static void QuitDriver(IWebDriver driver)
        {
            if (driver == null) return;

            Action[] actions =
            {
                () => ((IDevTools)driver).CloseDevToolsSession(),
                () => driver.Manage().Cookies.DeleteAllCookies(),
                () => driver.Close(),
                () => driver.Quit(),
                () => driver.Dispose()
            };

            Type[] exceptionTypes = { typeof(CommandResponseException), typeof(WebDriverException), typeof(NullReferenceException) };

            foreach (var action in actions)
            {
                ObjectExtensions.IgnoringFailure(action, exceptionTypes);
            }
        }

        public static IWebDriver? GetDriver()
            => Driver?.Value;
    }
}