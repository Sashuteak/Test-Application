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
    class MenuNavigate_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        public MenuNavigate_Test(AndroidDriver<IWebElement> dri, TextBox obj) : base(dri, obj)
        {
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            TableViewClick();
            GoToFavorite();
            driver.PressKeyCode(AndroidKeyCode.Back);
            GoToFilter().CloseClick();
            SearchClick();
            driver.PressKeyCode(AndroidKeyCode.Back);
            SliderViewClick();
        }
    }
}
