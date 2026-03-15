using OpenQA.Selenium;
using SwagLabs.Core.Config;
using SwagLabs.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabs.PageObjects.Pages
{
    public class InventoryItemPage : BasePage
    {
        private readonly By addToCartBtn = ByTestId("add-to-cart");
        private readonly By itemName = ByTestId("inventory-item-name");
        public InventoryItemPage(IWebDriver driver, TestConfiguration config) : base(driver, config) { }

        public void AddToCart()
        {
            WaitForElement(itemName);
            WaitForClickable(addToCartBtn).Click();
        }

    }
}
