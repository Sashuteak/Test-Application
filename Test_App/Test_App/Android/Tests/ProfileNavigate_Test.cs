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
    class ProfileNavigate_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        public ProfileNavigate_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            AndroidNavigatePage nav = NavigateClick();
            nav.ProfileClick();
            NavigateClick();
            nav.TicketsClick();
            driver.PressKeyCode(AndroidKeyCode.Back);
            NavigateClick();
            nav.FinanceClick();
            NavigateClick();
            nav.TermsClick();
            NavigateClick();
            nav.SupportClick();
            driver.FindElementById("com.karabas:id/close").Click();
            base.EventsClick();
        }
    }
}
