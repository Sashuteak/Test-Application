using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class MainNavigate_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        public MainNavigate_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            StoreClick();
            OnEventClick();
            BasketClick();
            driver.PressKeyCode(AndroidKeyCode.Back);
            EventsClick();
        }
    }
}
