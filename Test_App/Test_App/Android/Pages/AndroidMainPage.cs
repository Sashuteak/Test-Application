using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_App.Android.Pages
{
    abstract class AndroidMainPage
    {
        TextBox textBox;
        AndroidDriver<IWebElement> driver;
        public AndroidMainPage(AndroidDriver<IWebElement> dri, TextBox obj)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            textBox = obj;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/store")]
        protected IWebElement store;

        [FindsBy(How = How.Id, Using = "com.karabas:id/on_event")]
        protected IWebElement on_event;

        [FindsBy(How = How.Id, Using = "com.karabas:id/basket")]
        protected IWebElement basket;

        [FindsBy(How = How.Id, Using = "com.karabas:id/events")]
        protected IWebElement events;

        [FindsBy(How = How.Id, Using = "com.karabas:id/search")]
        protected IWebElement search_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/et_search")]
        protected IWebElement search_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/iv_filter")]
        protected IWebElement filter;

        [FindsBy(How = How.Id, Using = "com.karabas:id/rl_favorite")]
        protected IWebElement favorite;

        [FindsBy(How = How.Id, Using = "com.karabas:id/iv_view_table")]
        protected IWebElement view_table;

        [FindsBy(How = How.Id, Using = "com.karabas:id/iv_view_slider")]
        protected IWebElement view_slider;

        [FindsBy(How = How.ClassName, Using = "android.widget.ImageButton")]
        protected IWebElement Navigate;

        [FindsBy(How = How.Id, Using = "com.karabas:id/cb_fav")]
        protected IWebElement fave;

        [FindsBy(How = How.XPath, Using = "//android.widget.FrameLayout/android.support.v4.view.ViewPager/android.widget.RelativeLayout[@clickable=\"true\"]")]
        protected IWebElement Events_List;

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        public IList<IWebElement> MonthList { get; set; }



        public AndroidEventPage EventsListItemClick()
        {
            Events_List.Click();
            return new AndroidEventPage(driver, textBox);
        }
        public abstract void GoTest();
        public AndroidStorePage StoreClick()
        {
            textBox.AppendText("Step To -> Store\r\n");
            store.Click();
            return new AndroidStorePage(driver, textBox);
        }
        public AndroidNavigatePage NavigateClick()
        {
            Navigate.Click();
            textBox.AppendText("Step To -> " + Navigate.GetAttribute("name") + "\r\n");
            return new AndroidNavigatePage(driver, textBox);
        }
        public void SearchClick()
        {
            search_button.Click();
            textBox.AppendText("Step To -> Search\r\n");
        }
        public void SetSearchField(string value)
        {
            search_field.SendKeys(value);
        }
        public void ClickSearchField()
        {
            search_field.Click();
        }
        public void FaveClick()
        {
            textBox.AppendText("Step -> Add To Favrite\r\n");
            fave.Click();
        }
        public FavoritePage GoToFavorite()
        {
            textBox.AppendText("Step -> To Favrite\r\n");
            favorite.Click();
            return new FavoritePage(driver, textBox);
        }
        public void EventsClick()
        {
            textBox.AppendText("Step To -> Events\r\n");
            events.Click();
        }
        public void OnEventClick()
        {
            textBox.AppendText("Step To -> On Event\r\n");
            on_event.Click();
        }
        public BasketPage BasketClick()
        {
            textBox.AppendText("Step To -> Basket\r\n");
            basket.Click();
            return new BasketPage(driver, textBox);
        }
        public void MonthClick(int index)
        {
            MonthList[index].Click();
            //textBox.AppendText("Step To -> " + MonthList[index].Text + "\r\n");
        }
        public void TableViewClick()
        {
            view_table.Click();
            textBox.AppendText("Step To -> Table Events\r\n");
        }
        public void SliderViewClick()
        {
            view_slider.Click();
            //textBox.AppendText("Step To -> Slider Events\r\n");
        }
        public AndroidFilterPage GoToFilter()
        {
            filter.Click();
            textBox.AppendText("Step To -> Filter\r\n");
            return new AndroidFilterPage(driver, textBox);
        }
    }
}
