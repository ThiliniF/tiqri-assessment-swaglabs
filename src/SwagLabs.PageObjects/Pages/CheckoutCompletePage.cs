using OpenQA.Selenium;
using SwagLabs.Core.Config;
using SwagLabs.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabs.PageObjects.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private readonly By completeHeader = ByTestId("complete-header");
        private readonly By backHomeBtn = ByTestId("back-to-products");

        public CheckoutCompletePage(IWebDriver driver, TestConfiguration config) : base(driver, config) { }

        public bool IsOrderConfirmationDisplayed()
        {
            return WaitForElement(completeHeader).Displayed;
        }

        public void ClickOnBackHomeBtn()
        {
            WaitForClickable(backHomeBtn).Click();
        }
    }
}
