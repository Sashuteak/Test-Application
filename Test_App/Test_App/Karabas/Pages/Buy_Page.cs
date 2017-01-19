using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Test_App.Karabas.Pages
{
    public class Buy_Page
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "link_buy_ticket")]
        private IWebElement go_to_buy_page;

        [FindsBy(How = How.CssSelector, Using = ".open-cart-event")]
        private IWebElement open_cart_event;

        [FindsBy(How = How.CssSelector, Using = ".user-cart")]
        private IWebElement user_cart;

        public Buy_Page(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            this.driver = browser;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
        }
        public void Click_To_Cart_Event()
        {
            open_cart_event.Click();
        }
        public void Click_To_Buy()
        {
            ActionMethods.Hover(driver, go_to_buy_page);
            go_to_buy_page.Click();
        }
        public void Click_To_Cart()
        {
            user_cart.Click();
        }
    }
}
