using OpenQA.Selenium;
using SwagLabs.Core.Config;
using SwagLabs.Core.Helpers;

namespace SwagLabs.PageObjects.Base
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly TestConfiguration Config;

        protected BasePage(IWebDriver driver, TestConfiguration config)
        {
            Driver = driver;
            Config = config;
        }

        protected static By ByTestId(string testId)
        {
            return By.CssSelector($"[data-test='{testId}']");
        }
        protected IWebElement WaitForElement(By locator)
        {
            return WaitHelper.WaitForElement(Driver, locator, Config.ExplicitWaitSeconds);
        }

        protected IWebElement WaitForClickable(By locator)
        {
            return WaitHelper.WaitForElementClickable(Driver, locator, Config.ExplicitWaitSeconds);
        }
        
        protected void NavigateTo(string relativePath = "")
        {
            Driver.Navigate().GoToUrl(Config.BaseUrl + relativePath);
        }
    }
}
