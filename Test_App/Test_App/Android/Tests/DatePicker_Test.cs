using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class DatePicker_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public DatePicker_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.textBox = textBox;
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            AndroidFilterPage filter = GoToFilter();

            filter.ScrollToDate();
            filter.DateFromClick();


            for (int i = 0; i < 2; i++)
            {
                try
                {
                    driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().className(\"android.widget.ListView\")).scrollForward();"));
                }
                catch { }
            }

            IWebElement obj = driver.FindElementsByClassName("android.view.View")[3];
            textBox.AppendText("Make a choice -> " + obj.GetAttribute("name") + "\r\n");
            obj.Click();

            obj = driver.FindElementById("com.karabas:id/ok");
            textBox.AppendText("Step To -> " + obj.Text + "\r\n");
            obj.Click();

            filter.ScrollToDate();
            filter.SubmitClick();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));

            obj = driver.FindElementByXPath("//android.widget.RelativeLayout[@resource-id='com.karabas:id/root'][@clickable='true']" +
                "//android.widget.TextView[@resource-id='com.karabas:id/tv_when']");
            textBox.AppendText("Search Result Date-> " + obj.Text + "\r\n");

            obj = driver.FindElementByXPath("//android.widget.RelativeLayout[@resource-id='com.karabas:id/root'][@clickable='true']" +
                "//android.widget.TextView[@resource-id='com.karabas:id/tv_title']");
            textBox.AppendText("Search Result Event-> " + obj.GetAttribute("name") + "\r\n");

            filter.CloseClick();
            filter.ClearFilter();
            filter.CloseClick();
        }
    }
}
