using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class FilterCategories_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public FilterCategories_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.textBox = textBox;
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        public override void GoTest()
        {
            AndroidFilterPage filt = GoToFilter();
            Result_Page rp;
            string value;
            for (int i = 0; i < filt.Categories.Count; i++)
            {
                value = filt.CategoriesClick(i);
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().resourceId(\"com.karabas:id/parent_scroll\")).scrollForward();"));
                }
                catch { }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                rp = filt.SubmitClick();

                try
                {
                    if (rp.search_result.Displayed)
                    {
                        textBox.AppendText("Actual Search Result -> " + rp.search_result.Text + "\r\n");
                    }
                    else
                    {
                        throw new Exception("Нет Мероприятий на Эту Категорию!");
                    }
                }
                catch (Exception e)
                {

                    textBox.AppendText(e.Message + "\r\n");
                }
                filt.CloseClick();
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().resourceId(\"com.karabas:id/parent_scroll\")).scrollBackward();"));
                }
                catch { }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                filt.ClearFilter();
                textBox.AppendText("\r\n");
            }
            filt.CloseClick();
        }
    }
}
