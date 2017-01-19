using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class CityPick_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public CityPick_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.textBox = textBox;
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            AndroidFilterPage filter = GoToFilter();
            filter.ScrollToDate();
            AndroidLocationPage location_page = filter.LocationClick();

            location_page.CityClick();

            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
                driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().resourceId(\"com.karabas:id/scrollview\")).flingForward();"));
            }
            catch { }

            driver.FindElementsByClassName("android.widget.RelativeLayout")[2].Click();

            location_page.ButtonOkClick();
            textBox.AppendText("Your City Choice -> " + filter.location.Text + "\r\n");

            //filter.ScrollToDate();
            filter.SubmitClick();

            try
            {
                driver.FindElementByXPath("//android.widget.RelativeLayout[@resource-id='com.karabas:id/root']").Click();
                textBox.AppendText("Step To -> Event\r\n");

                textBox.AppendText("Search Result  -  " + driver.FindElementById("com.karabas:id/tv_when").Text + "\r\n");

                driver.PressKeyCode(AndroidKeyCode.Back);
                filter.CloseClick();
                filter.ClearFilter();
                filter.CloseClick();
            }
            catch (Exception e)
            {
                textBox.AppendText(e.Message);
                filter.CloseClick();
                filter.ClearFilter();
                filter.CloseClick();
            }


            
        }
    }
}
