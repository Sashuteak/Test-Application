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
    class BasketPage
    {
        TextBox textBox;
        AndroidDriver<IWebElement> driver;
        public BasketPage(AndroidDriver<IWebElement> dri, TextBox obj)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            textBox = obj;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/iv_remove_from_basket")]
        private IWebElement remove_from_basket;

        [FindsBy(How = How.Id, Using = "com.karabas:id/tv_basket_price")]
        public IWebElement basket_price { get; set; }

        [FindsBy(How = How.Id, Using = "com.karabas:id/tv_text")]
        public IWebElement name_text { get; set; }

        [FindsBy(How = How.Id, Using = "com.karabas:id/btn_make_order")]
        private IWebElement btn_make_order;

        public void RemoveProduct()
        {
            remove_from_basket.Click();
        }
    }
}
