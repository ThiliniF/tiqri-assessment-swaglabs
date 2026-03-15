using OpenQA.Selenium;
using Reqnroll.BoDi;
using SwagLabs.Core.Config;
using SwagLabs.Core.Driver;
using SwagLabs.Definitions.Support;

namespace SwagLabs.Definitions.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly DriverContext context;
        private readonly IObjectContainer container;

        public Hooks(DriverContext driverContext, IObjectContainer objectContainer)
        {
            context = driverContext;
            container = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var config = TestConfiguration.Load();
            IDriverFactory driverFactory = new WebDriverFactory(config);
            IWebDriver driver = driverFactory.CreateDriver();

            container.RegisterInstanceAs(config);
            container.RegisterInstanceAs(driverFactory);
            container.RegisterInstanceAs(driver);

            context.Config = config;
            context.Driver = driver;
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null && context.Driver is ITakesScreenshot screenshotDriver)
            {
                var screenshot = screenshotDriver.GetScreenshot();
                var safeName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
                var fileName = $"{safeName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                var dir = Path.Combine("TestResults", "Screenshots");
                Directory.CreateDirectory(dir);
                screenshot.SaveAsFile(Path.Combine(dir, fileName));
            }
            context.QuitDriver();
        }
    }
}
