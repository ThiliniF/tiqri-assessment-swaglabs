using OpenQA.Selenium;
using SwagLabs.Core.Config;

namespace SwagLabs.Definitions.Support
{
    public class DriverContext
    {
        private IWebDriver? driver;
        private TestConfiguration? config;

        public IWebDriver Driver
        {
            get => driver ?? throw new InvalidOperationException(
                "WebDriver has not been initialized. Ensure BeforeScenario hook ran successfully.");
            set => driver = value;
        }

        public TestConfiguration Config
        {
            get => config ?? throw new InvalidOperationException(
                "TestConfiguration has not been initialized. Ensure BeforeScenario hook ran successfully.");
            set => config = value;
        }

        public void QuitDriver()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
