using OpenQA.Selenium;
using SwagLabs.Core.Config;
using SwagLabs.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabs.PageObjects.Pages
{
    public class CartPage : BasePage
    {
        private readonly By checkoutBtn = ByTestId("checkout");
        private readonly By cartTitle = ByTestId("title");
        public CartPage(IWebDriver driver, TestConfiguration config) : base(driver, config) { }

        public void ClickCheckoutBtn()
        {
            WaitForElement(cartTitle);
            WaitForClickable(checkoutBtn).Click();
        }
    }
}
