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

        [BeforeScenario]
        public void BeforeScenario()
        {
            var config = TestConfiguration.Load();
            var driver = new WebDriverFactory(config).CreateDriver();
            context.Config = config;
            context.Driver = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            context.Driver.Quit();
            context.Driver.Dispose();
        }
    }
}
