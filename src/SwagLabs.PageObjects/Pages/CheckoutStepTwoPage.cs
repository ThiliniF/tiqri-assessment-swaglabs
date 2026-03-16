using OpenQA.Selenium;
using SwagLabs.Core.Config;
using SwagLabs.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SwagLabs.PageObjects.Pages
{
    public class CheckoutStepTwoPage : BasePage
    {
        private readonly By itemPriceLbl = ByTestId("inventory-item-price");
        private readonly By paymentInfoLbl = ByTestId("payment-info-value");
        private readonly By shippingInfoLbl = ByTestId("shipping-info-value");
        private readonly By subtotalLbl = ByTestId("subtotal-label");
        private readonly By taxLbl = ByTestId("tax-label");
        private readonly By totalLbl = ByTestId("total-label");
        private readonly By finishBtn = ByTestId("finish");

        public CheckoutStepTwoPage(IWebDriver driver, TestConfiguration config) : base(driver, config) { }

        public List<decimal> GetItemPrices()
        {
            return Driver.FindElements(itemPriceLbl)
                         .Select(e => ParsePrice(e.Text))
                         .ToList();
        }

        public bool IsPaymentInfoDisplayed()
        {
            return !string.IsNullOrWhiteSpace(WaitForElement(paymentInfoLbl).Text);
        }

        public bool IsShippingInfoDisplayed()
        {
            return !string.IsNullOrWhiteSpace(WaitForElement(shippingInfoLbl).Text);
        }

        public decimal GetItemTotal()
        {
            return ParsePrice(WaitForElement(subtotalLbl).Text);  // "Item total: $29.99"
        }

        public decimal GetTax()
        {
            return ParsePrice(WaitForElement(taxLbl).Text);       // "Tax: $2.40"
        }

        public decimal GetOrderTotal()
        {
            return ParsePrice(WaitForElement(totalLbl).Text);     // "Total: $32.39"
        }

        private static decimal ParsePrice(string text)
        {
            var match = Regex.Match(text, @"\$(\d+\.\d{2})");
            if (!match.Success)
                throw new FormatException($"Could not parse price from: '{text}'");
            return decimal.Parse(match.Groups[1].Value);
        }

        public void clickOnFinishBtn()
        {
            WaitForElement(finishBtn).Click();
        }
    }
}
