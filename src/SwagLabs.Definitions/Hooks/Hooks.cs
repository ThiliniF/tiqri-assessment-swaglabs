using SwagLabs.Core.Config;
using SwagLabs.Core.Driver;
using SwagLabs.Definitions.Support;

namespace SwagLabs.Definitions.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly DriverContext context;

        public Hooks(DriverContext driverContext)
        {
            context = driverContext;
        }

        [BeforeFeature]
        public void BeforeScenario()
        {
            var config = TestConfiguration.Load();
            var driver = new WebDriverFactory(config).CreateDriver();
            context.Config = config;
            context.Driver = driver;
        }

        [AfterFeature]
        public void AfterScenario()
        {
            context.Driver.Quit();
            context.Driver.Dispose();
        }
    }
}
