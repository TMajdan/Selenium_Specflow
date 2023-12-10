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

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}