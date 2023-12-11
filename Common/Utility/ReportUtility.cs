#pragma warning disable CS8602 // Dereference of a possibly null reference.

using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;

namespace Task_TMajdan.Utility
{
    internal class ReportUtility : ExtentReport
    {
        public static void SaveTestsStepToReport(ScenarioContext scenarioContext, IWebDriver _driver, IObjectContainer _container)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();

            var node = scenarioContext.TestError == null
                ? CreateNode(_scenario, stepType, stepName)
                : CreateNodeWithFailure(_scenario, stepType, stepName, driver, scenarioContext);
        }

        private static ExtentTest CreateNode(ExtentTest scenario, string stepType, string stepName)
        {
            return stepType switch
            {
                "Given" => scenario.CreateNode<Given>(stepName),
                "When" => scenario.CreateNode<When>(stepName),
                "Then" => scenario.CreateNode<Then>(stepName),
                "And" => scenario.CreateNode<And>(stepName),
                _ => throw new ArgumentOutOfRangeException(nameof(stepType), $"Step type '{stepType}' is not recognized."),
            };
        }

        private static ExtentTest CreateNodeWithFailure(ExtentTest scenario, string stepType, string stepName, IWebDriver driver, ScenarioContext scenarioContext)
        {
            return CreateNode(scenario, stepType, stepName)
                .Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
        }
    }
}
