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
        public CartPage(IWebDriver driver, TestConfiguration config) : base(driver, config) { }

        public void ClickCheckoutBtn()
        {
            WaitForClickable(checkoutBtn).Click();
        }
    }
}
