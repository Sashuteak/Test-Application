using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Test_App.Karabas.Pages
{
    public class Event_Page
    {
        [FindsBy(How = How.CssSelector, Using = ".slick-track .slick-active")]
        public IWebElement go_to_event;

        [FindsBy(How = How.CssSelector, Using = ".el-club")]
        public IWebElement location;

        [FindsBy(How = How.CssSelector, Using = "#popup-concert .icon-clear")]
        public IWebElement close_location;

        [FindsBy(How = How.CssSelector, Using = ".back-button button[type=\"button\"]")]
        public IWebElement back;

        [FindsBy(How = How.CssSelector, Using = ".social a[target=\"_blank\"]")]
        public IWebElement tell_vk;

        [FindsBy(How = How.CssSelector, Using = ".social a[id=\"share_button\"]")]
        public IWebElement tell_fb;

        [FindsBy(How = How.CssSelector, Using = ".social a[class=\"s-inst\"]")]
        public IWebElement tell_inst;

        [FindsBy(How = How.CssSelector, Using = "button[data-tab=\"ct-about\"]")]
        public IWebElement description;

        [FindsBy(How = How.CssSelector, Using = "button[data-tab=\"ct-comment\"]")]
        public IWebElement comments;

        [FindsBy(How = How.CssSelector, Using = "button[data-tab=\"ct-tour\"]")]
        public IWebElement tour;

        public Event_Page(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }
    }
}
