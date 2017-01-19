using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_App.Android.Pages
{
    class AndroidFilterPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public AndroidFilterPage(AndroidDriver<IWebElement> dri, TextBox textBox)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            this.textBox = textBox;
        }

        [FindsBy(How = How.ClassName, Using = "android.widget.CheckBox")]
        public IList<IWebElement> Categories { get; set; }

        [FindsBy(How = How.Id, Using = "com.karabas:id/close_search")]
        private IWebElement close;

        [FindsBy(How = How.Id, Using = "com.karabas:id/tv_filter_underline")]
        private IWebElement clear_filter;

        [FindsBy(How = How.Id, Using = "com.karabas:id/btn_filter")]
        public IWebElement submit_search_buttton { get; set; }

        [FindsBy(How = How.Id, Using = "com.karabas:id/cb_on_this_week")]
        private IWebElement on_this_week;

        [FindsBy(How = How.Id, Using = "com.karabas:id/cb_first_month")]
        private IWebElement first_month;

        [FindsBy(How = How.Id, Using = "com.karabas:id/second_month")]
        private IWebElement second_month;

        [FindsBy(How = How.Id, Using = "com.karabas:id/cb_third_month")]
        private IWebElement third_month;

        [FindsBy(How = How.Id, Using = "com.karabas:id/date_from_parent")]
        private IWebElement date_from_parent;

        [FindsBy(How = How.Id, Using = "com.karabas:id/date_to_parent")]
        private IWebElement date_to_parent;

        [FindsBy(How = How.Id, Using = "com.karabas:id/tv_location")]
        public IWebElement location { get; set; }

        [FindsBy(How = How.Id, Using = "com.karabas:id/tv_add_location")]
        private IWebElement add_location;

        [FindsBy(How = How.Id, Using = "com.karabas:id/fl_halls")]
        private IWebElement all_halls;

        [FindsBy(How = How.Id, Using = "com.karabas:id/rl_price_from")]
        private IWebElement price_from;

        [FindsBy(How = How.Id, Using = "com.karabas:id/rl_price_to")]
        private IWebElement price_to;


        public string CategoriesClick(int index)
        {
            Categories[index].Click();
            textBox.AppendText("Step To -> " + Categories[index].Text + "\r\n");
            return Categories[index].Text;
        }
        public void CloseClick()
        {
            close.Click();
        }
        public void ClearFilter()
        {
            clear_filter.Click();
            textBox.AppendText("Step To -> " + clear_filter.Text + "\r\n");
        }
        public Result_Page SubmitClick()
        {
            while (true)
            {
                if (submit_search_buttton.Displayed)
                {
                    textBox.AppendText("Step To -> " + submit_search_buttton.Text + "\r\n");
                    submit_search_buttton.Click();
                    return new Result_Page(driver, textBox);
                }
                else
                {
                    try
                    {
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
                        driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().resourceId(\"com.karabas:id/parent_scroll\")).scrollForward();"));
                    }
                    catch { }
                }
            }
        }
        public void ScrollToDate()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
                driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().resourceId(\"com.karabas:id/parent_scroll\")).flingForward();"));
            }
            catch { }
        }
        public void DateFromClick()
        {
            textBox.AppendText("Step To Default Date -> " + driver.FindElementById("com.karabas:id/date_from").Text + "\r\n");
            date_from_parent.Click();
        }
        public DatePage DateToClick()
        {
            textBox.AppendText("Step To Default Date -> " + driver.FindElementById("com.karabas:id/date_to").Text + "\r\n");
            date_to_parent.Click();
            return new DatePage(driver, textBox);
        }
        public AndroidLocationPage LocationClick()
        {
            textBox.AppendText("Step To -> " + location.Text + "\r\n");
            location.Click();
            return new AndroidLocationPage(driver, textBox);
        }
    }
}
