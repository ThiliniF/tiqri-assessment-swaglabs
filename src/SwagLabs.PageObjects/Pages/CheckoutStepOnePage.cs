using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using SwagLabs.Core.Config;
using SwagLabs.PageObjects.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabs.PageObjects.Pages
{
    public class CheckoutStepOnePage : BasePage
    {
        private readonly By title = ByTestId("title");
        private readonly By firstNameInput = ByTestId("firstName");
        private readonly By lastNameInput = ByTestId("lastName");
        private readonly By zipCodeInput = ByTestId("postalCode");
        private readonly By continueBtn = ByTestId("continue");
        private readonly By cancelBtn = ByTestId("cancel");

        public CheckoutStepOnePage(IWebDriver driver, TestConfiguration config): base(driver, config) { }

        public string ExtractPageTitle()
        {
            return WaitForElement(title).Text;
        }

        public bool IsFieldVisible(string fieldLabel)
        {
            var fields = new Dictionary<string, By>
              {
                  { "First Name",      firstNameInput },
                  { "Last Name",       lastNameInput  },
                  { "Zip/Postal Code", zipCodeInput   }
              };

            return WaitForElement(fields[fieldLabel]).Displayed;
        }

        public bool IsButtonVisible(string buttonLabel) {
            var buttons = new Dictionary<string, By>
              {
                  { "Continue", continueBtn },
                  { "Cancel",   cancelBtn   }
              };

            return WaitForElement(buttons[buttonLabel]).Displayed;
        }
    }
}
