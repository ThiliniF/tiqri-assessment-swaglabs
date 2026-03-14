using OpenQA.Selenium;
using SwagLabs.Core.Config;
using SwagLabs.PageObjects.Base;

namespace SwagLabs.PageObjects.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By usernameInput = ByTestId("username");
        private readonly By passwordInput = ByTestId("password");
        private readonly By loginBtn = ByTestId("login-button");

        public LoginPage(IWebDriver driver, TestConfiguration config) : base(driver, config) { }

        public void NavigateToLoginPage()
        {
            NavigateTo();
        }

        public void EnterUsername(string username)
        {
            WaitForElement(usernameInput).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            WaitForElement(passwordInput).SendKeys(password);
        }

        public void ClickOnLoginBtn()
        {
            WaitForClickable(loginBtn).Click();
        }

        public void Login(string username, string password)
        {
            NavigateToLoginPage();
            EnterUsername(username);
            EnterPassword(password);
            ClickOnLoginBtn();
        }
    }
}
