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
        private readonly By itemPrice = ByTestId("inventory-item-price");
        public InventoryItemPage(IWebDriver driver, TestConfiguration config) : base(driver, config) { }

        public void AddToCart()
        {
            WaitForElement(itemName);
            WaitForClickable(addToCartBtn).Click();
        }
        public decimal GetItemPrice()
        {
            var priceText = WaitForElement(itemPrice).Text;
            return decimal.Parse(priceText.TrimStart('$'));
        }

    }
}
