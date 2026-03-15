using DotNetEnv;
using Microsoft.Extensions.Configuration;

namespace SwagLabs.Core.Config
{
    public class TestConfiguration
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Browser {  get; set; } = "Chrome";
        public int ExplicitWaitSeconds { get; set; } = 15;
        public int PageLoadTimeoutSeconds { get; set; } = 15;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public static TestConfiguration Load()
        {
            Env.TraversePath().Load();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            var settings = config.Get<TestConfiguration>()
                 ?? throw new InvalidOperationException("Failed to load TestConfiguration.");

            if (string.IsNullOrEmpty(settings.Username) || string.IsNullOrEmpty(settings.Password))
                throw new InvalidOperationException(
                    "Username and Password must be provided via .env file or environment variables.");

            return settings;
        }
    }
}
