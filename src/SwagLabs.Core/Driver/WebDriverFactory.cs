using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SwagLabs.Core.Config;

namespace SwagLabs.Core.Driver
{
    public class WebDriverFactory : IDriverFactory
    {
        private readonly TestConfiguration config;

        public WebDriverFactory(TestConfiguration testConfig)
        {
            config = testConfig;
        }

        public IWebDriver CreateDriver()
        {
            var browserType = Enum.Parse<BrowserType>(config.Browser, ignoreCase: true);

            IWebDriver driver = browserType switch
            {
                BrowserType.Chrome => CreateChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Edge => new EdgeDriver(),
                _ => throw new ArgumentOutOfRangeException($"Unsupported browser: {config.Browser}")
            };

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(config.PageLoadTimeoutSeconds);
            driver.Manage().Window.Maximize();

            return driver;
        }

        private static ChromeDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            if(Environment.GetEnvironmentVariable("CI") == "true")
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
            }
            return new ChromeDriver(options);
        }
    }
}
