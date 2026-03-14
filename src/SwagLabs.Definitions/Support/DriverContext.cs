using OpenQA.Selenium;
using SwagLabs.Core.Config;

namespace SwagLabs.Definitions.Support
{
    public class DriverContext
    {
        public IWebDriver? Driver { get; set; } = null;
        public TestConfiguration? Config { get; set; } = null;
    }
}
