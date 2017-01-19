using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace Test_App.Android.Pages
{
    class AndroidLoginPage
    {
        AndroidDriver<IWebElement> driver;
        public AndroidLoginPage(AndroidDriver<IWebElement> dri)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/fb_login")]
        private IWebElement fb_login;

        [FindsBy(How = How.Id, Using = "com.karabas:id/vk_login")]
        private IWebElement vk_login;

        [FindsBy(How = How.Id, Using = "com.karabas:id/et_login")]
        private IWebElement phone_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/btn_ok")]
        private IWebElement btn_ok;

        [FindsBy(How = How.Id, Using = "com.karabas:id/registration")]
        private IWebElement registration;


        public AndroidRegistrationPage RegClick()
        {
            registration.Click();
            return new AndroidRegistrationPage(driver);
        }
        public void SetPhoneField()
        {
            phone_field.SendKeys("+380936759070");
            btn_ok.Click();
        }
    }
}
