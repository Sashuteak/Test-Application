using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class Month_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        public Month_Test(AndroidDriver<IWebElement> dri, TextBox obj) : base(dri, obj)
        {
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }
        public override void GoTest()
        {
            for (int i = 1; i < 6; i++)
            {
                MonthClick(i);
            }
        }
    }
}
