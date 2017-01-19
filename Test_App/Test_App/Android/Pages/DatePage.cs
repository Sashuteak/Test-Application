using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_App.Android.Pages
{
    class DatePage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public DatePage(AndroidDriver<IWebElement> dri, TextBox textBox)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            this.textBox = textBox;
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/date_picker_year")]
        private IWebElement date_picker_year;

        [FindsBy(How = How.Id, Using = "com.karabas:id/com.karabas:id/date_picker_month_and_day")]
        private IWebElement date_picker_month_and_day;

        [FindsBy(How = How.Id, Using = "com.karabas:id/ok")]
        private IWebElement ok_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/cancel")]
        private IWebElement cancel_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/month_text_view")]
        public IList<IWebElement> year_choise { get; set; }


        public void ScrollUntil(string value)
        {
            for (int i = 0; ; i++)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
                    driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().className(\"android.widget.ListView\")).scrollForward();"));
                }
                catch { }
                for (int j = 0; j < year_choise.Count; j++)
                {
                    if (year_choise[j].Text == value)
                    {
                        year_choise[j].Click();
                        SubmitClick();
                        return;
                    }
                }
            }
        }
        public void PickYearClick()
        {
            date_picker_year.Click();
        }
        public void ChooseYear(int index)
        {
            year_choise[index].Click();
        }
        public void SubmitClick()
        {
            ok_button.Click();
        }
    }
}
