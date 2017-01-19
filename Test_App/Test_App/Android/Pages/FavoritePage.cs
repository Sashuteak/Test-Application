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
    class FavoritePage
    {
        TextBox textBox;
        AndroidDriver<IWebElement> driver;
        public FavoritePage(AndroidDriver<IWebElement> dri, TextBox obj)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            textBox = obj;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/close_search")]
        protected IWebElement close_favorite;

        [FindsBy(How = How.XPath, Using = "//android.widget.RelativeLayout[@resource-id=\"com.karabas:id/rl_filter\"]/android.widget.TextView[@resource-id=\"com.karabas:id/tv_count\"]")]
        protected IWebElement cunt;

        [FindsBy(How = How.XPath, Using = "//android.support.v4.view.ViewPager//android.widget.TextView[@resource-id=\"com.karabas:id/tv_title\"]")]
        protected IWebElement title;

        [FindsBy(How = How.ClassName, Using = "android.widget.RelativeLayout")]
        protected IList<IWebElement> favorit_list;


        public void GetTitle()
        {
            textBox.AppendText("Event Actual In Favorire -> " + title.Text + "\r\n");
        }
        internal void CloseFavorite()
        {
            close_favorite.Click();
            textBox.AppendText("Step To -> Close Favorite\r\n");
        }
    }
}
