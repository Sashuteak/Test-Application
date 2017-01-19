using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_App.Android.Pages
{
    class AndroidStorePage
    {
        TextBox textBox;
        AndroidDriver<IWebElement> driver;
        public AndroidStorePage(AndroidDriver<IWebElement> dri, TextBox obj)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            textBox = obj;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/rl_favorite")]
        private IWebElement store_favorite;

        [FindsBy(How = How.Id, Using = "com.karabas:id/search")]
        private IWebElement store_search;

        [FindsBy(How = How.Id, Using = "com.karabas:id/cb_fav")]
        private IWebElement store_add_favorit;

        [FindsBy(How = How.ClassName, Using = "android.widget.FrameLayout")]
        private IList<IWebElement> products;

        [FindsBy(How = How.XPath, Using = "//android.widget.FrameLayout[@clickable='true']//android.widget.TextView[@resource-id='com.karabas:id/tv_title']")]
        public IWebElement product_name { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.FrameLayout[@clickable='true']//android.widget.TextView[@resource-id='com.karabas:id/tv_price']")]
        public IWebElement product_price { get; set; }


        public void GoToFAvorit()
        {
            store_favorite.Click();
        }
        public void GoToStoreSearch()
        {
            store_search.Click();
        }
        public void AddToFavorit()
        {
            store_add_favorit.Click();
        }
        public BuyProductPAge СhooseProduct(int index)
        {
            products[index].Click();
            return new BuyProductPAge(driver, textBox);
        }
        public void GoTOProductFAvorite()
        {
            store_favorite.Click();
        }
    }
}
