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
            _scenario = stepType switch
            {
                "Given" => _scenario.CreateNode<Given>(stepName),
                "When" => _scenario.CreateNode<When>(stepName),
                "Then" => _scenario.CreateNode<Then>(stepName),
                "And" => _scenario.CreateNode<And>(stepName),
                _ => throw new ArgumentException($"Invalid stepType: {stepType}"),
            };
        }

        private static void CreateNodeWithStatusAndFailure(string stepType, string stepName, string errorMessage, MediaEntityModelProvider screenshot)
        {
            var node = GetNodeByType(stepType, stepName);
            node.Fail(errorMessage, screenshot);
        }

        private static ExtentTest GetNodeByType(string stepType, string stepName)
        {
           return stepType switch
            {
                "Given" => _scenario.CreateNode<Given>(stepName),
                "When" => _scenario.CreateNode<When>(stepName),
                "Then" => _scenario.CreateNode<Then>(stepName),
                "And" => _scenario.CreateNode<And>(stepName),
                _ => throw new ArgumentException($"Invalid stepType: {stepType}"),
            };
        }
    }
}