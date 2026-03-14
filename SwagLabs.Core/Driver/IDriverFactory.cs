using OpenQA.Selenium;

namespace SwagLabs.Core.Driver
{
    public interface IDriverFactory
    {
        IWebDriver CreateDriver();
    }
}
