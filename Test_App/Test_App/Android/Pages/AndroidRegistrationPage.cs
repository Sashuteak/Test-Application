using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace Test_App.Android.Pages
{
    class AndroidRegistrationPage
    {
        AndroidDriver<IWebElement> driver;
        public AndroidRegistrationPage(AndroidDriver<IWebElement> dri)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/et_first_name")]
        private IWebElement first_name_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/et_second_name")]
        private IWebElement last_name_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/et_number")]
        private IWebElement phone_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/et_mail")]
        private IWebElement email_field;

        [FindsBy(How = How.Id, Using = "com.karabas:id/btn_ok")]
        private IWebElement submit;

        [FindsBy(How = How.Id, Using = "com.karabas:id/enter")]
        private IWebElement back_to_login_page;


        public void SetFNAme(string fname)
        {
            first_name_field.SendKeys(fname);
        }
        public void SetLName(string lname)
        {
            last_name_field.SendKeys(lname);
        }
        public void SetPhone(string phone)
        {
            phone_field.SendKeys(phone);
        }
        public void SetEmail(string email)
        {
            email_field.SendKeys(email);
        }
        public void SubmitClick()
        {
            submit.Click();
        }
    }
}
