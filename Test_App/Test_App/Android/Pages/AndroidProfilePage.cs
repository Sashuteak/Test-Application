using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App.Android.Pages
{
    class AndroidProfilePage
    {
        AndroidDriver<IWebElement> driver;
        public AndroidProfilePage(AndroidDriver<IWebElement> dri)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/your_first_name")]
        private IWebElement your_first_name_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/your_second_name")]
        private IWebElement your_second_name_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/your_mail")]
        private IWebElement your_mail_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/your_number")]
        private IWebElement your_number_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/your_language")]
        private IWebElement your_language_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/your_country")]
        private IWebElement your_country_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/your_city")]
        private IWebElement your_city_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/vk")]
        private IWebElement vk_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/fb")]
        private IWebElement fb_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/btn_save")]
        private IWebElement save_button;

        [FindsBy(How = How.Id, Using = "com.karabas:id/tv_logout")]
        private IWebElement logout_button;

        public void LogoutClick()
        {
            logout_button.Click();
        }
    }
}
