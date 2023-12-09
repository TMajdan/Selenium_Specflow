#pragma warning disable CS8602 // Dereference of a possibly null reference.

using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;

namespace Task_TMajdan.Utility
{
    public class ReportUtility : ExtentReport
    {
        public static void SaveTestsStepToReport(ScenarioContext scenarioContext, IWebDriver _driver, IObjectContainer _container)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();
            var screenshot = MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build();

            if (scenarioContext.TestError == null)
            {
                CreateNodeWithStatus(stepType, stepName);
            }
            else
            {
                CreateNodeWithStatusAndFailure(stepType, stepName, scenarioContext.TestError.Message, screenshot);
            }
        }

        private static void CreateNodeWithStatus(string stepType, string stepName)
        {
            switch (stepType)
            {
                case "Given":
                    _scenario.CreateNode<Given>(stepName);
                    break;
                case "When":
                    _scenario.CreateNode<When>(stepName);
                    break;
                case "Then":
                    _scenario.CreateNode<Then>(stepName);
                    break;
                case "And":
                    _scenario.CreateNode<And>(stepName);
                    break;
            }
        }

        private static void CreateNodeWithStatusAndFailure(string stepType, string stepName, string errorMessage, MediaEntityModelProvider screenshot)
        {
            var node = GetNodeByType(stepType, stepName);
            node.Fail(errorMessage, screenshot);
        }

        private static ExtentTest GetNodeByType(string stepType, string stepName)
        {
            switch (stepType)
            {
                case "Given":
                    return _scenario.CreateNode<Given>(stepName);
                case "When":
                    return _scenario.CreateNode<When>(stepName);
                case "Then":
                    return _scenario.CreateNode<Then>(stepName);
                case "And":
                    return _scenario.CreateNode<And>(stepName);
                default:
                    throw new ArgumentException($"Invalid stepType: {stepType}");
            }
        }
    }
}