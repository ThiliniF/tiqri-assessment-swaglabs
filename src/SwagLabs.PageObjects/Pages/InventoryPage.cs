using OpenQA.Selenium;
using SwagLabs.Core.Config;
using SwagLabs.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabs.PageObjects.Pages
{
    public class InventoryPage : BasePage
    {
        private readonly By title = ByTestId("title");
        public InventoryPage(IWebDriver driver, TestConfiguration config) : base(driver, config) { }

        public string ExtractPageHeader(string pageName)
        {
            return WaitForElement(title).Text;
        }

        public void ClickOnProduct(string productName)
        {
            WaitForClickable(By.LinkText(productName)).Click();
        }
    }
}
