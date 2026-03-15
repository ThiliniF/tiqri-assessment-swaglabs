using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SwagLabs.Core.Helpers
{
    public static class WaitHelper
    {
        public static IWebElement WaitForElement(IWebDriver driver, By locator, int seconds = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitForElementClickable(IWebDriver driver, By locator, int seconds = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static bool WaitForUrl(IWebDriver driver, string partialUrl, int seconds = 20)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.UrlContains(partialUrl));
        }
    }
}
