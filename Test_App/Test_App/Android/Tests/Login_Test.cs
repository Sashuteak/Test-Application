using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class Login_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        public Login_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        public override void GoTest()
        {
            AndroidNavigatePage nav = NavigateClick();
            AndroidLoginPage log = nav.ProfileClick();
            log.SetPhoneField();
            NavigateClick();


            Assert.AreEqual("Пупкин Василий", driver.FindElementById("com.karabas:id/tv_name").Text);
            nav.ProfileClick();
            

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
                driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().className(\"android.widget.ScrollView\")).scrollForward();"));
            }
            catch { }
            AndroidProfilePage profile = new AndroidProfilePage(driver);
            profile.LogoutClick();
        }
    }
}
