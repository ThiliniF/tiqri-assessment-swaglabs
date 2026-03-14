using Microsoft.Extensions.Configuration;

namespace SwagLabs.Core.Config
{
    public class TestConfiguration
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Browser {  get; set; } = "Chrome";
        public int ExplicitWaitSeconds { get; set; } = 10;
        public int PageLoadTimeoutSeconds { get; set; } = 30;

        public static TestConfiguration Load()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            return config.Get<TestConfiguration>()
                ?? throw new InvalidOperationException("Failed to load TestConfiguration.");
        }
    }
}
