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
    class BuyProductPAge
    {
        TextBox textBox;
        AndroidDriver<IWebElement> driver;
        public BuyProductPAge(AndroidDriver<IWebElement> dri, TextBox obj)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            textBox = obj;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/close")]
        private IWebElement close;

        [FindsBy(How = How.Id, Using = "com.karabas:id/tv_name")]
        public  IWebElement product_name { get; set; }

        [FindsBy(How = How.Id, Using = "com.karabas:id/et_count")]
        private IWebElement count_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/btn_buy")]
        private IWebElement buy_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/btn_cancel")]
        private IWebElement cancel_button;


        public void CloseBuyPage()
        {
            close.Click();
        }
        public void SetCountField(string count)
        {
            count_field.SendKeys(count);
        }
        public void SubmitBuy()
        {
            buy_button.Click();
        }
        public void CancelBuy()
        {
            cancel_button.Click();
        }
    }
}
