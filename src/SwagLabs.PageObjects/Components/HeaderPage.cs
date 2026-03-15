using OpenQA.Selenium;
using SwagLabs.Core.Config;
using SwagLabs.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabs.PageObjects.Components
{
    public class HeaderPage : BasePage
    {
        private readonly By title = ByTestId("title");

        private readonly By cartLink = ByTestId("shopping-cart-link");
        public HeaderPage(IWebDriver driver, TestConfiguration config) : base(driver, config) { }

        public void ClickOnCart()
        {
            WaitForClickable(cartLink).Click();
        }
        public string ExtractPageTitle()
        {
            return WaitForElement(title).Text;
        }
    }
}
