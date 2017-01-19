using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_App.Android.Pages
{
    class PaymentPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public PaymentPage(AndroidDriver<IWebElement> dri, TextBox textBox)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            this.textBox = textBox;
        }

        [FindsBy(How = How.XPath, Using = "//android.webkit.WebView/android.view.View[@index='9']/android.widget.EditText")]
        private IWebElement card_number_field;

        [FindsBy(How = How.XPath, Using = "//android.webkit.WebView/android.view.View[@index='11']/android.widget.EditText")]
        private IWebElement date_field;

        [FindsBy(How = How.XPath, Using = "//android.webkit.WebView/android.view.View[@index='13']/android.widget.EditText")]
        private IWebElement crv_field;

        [FindsBy(How = How.XPath, Using = "//android.webkit.WebView/android.view.View[@index='14']")]
        private IWebElement confirm_button;


        public void SetCardNumber()
        {
            card_number_field.SendKeys("5457");
            card_number_field.SendKeys("5457 0822 3709 2726");
        }
        public void SetDateField()
        {
            date_field.SendKeys("0720");
        }
        public void SetCrvField()
        {
            crv_field.SendKeys("474");
        }
        public void Confirm()
        {
            confirm_button.Click();
        }
    }
}
