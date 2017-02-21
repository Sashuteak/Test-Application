using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_App.Android.Pages
{
    class AndroidEventPage
    {
        TextBox textBox;
        AndroidDriver<IWebElement> driver;
        public AndroidEventPage(AndroidDriver<IWebElement> dri, TextBox obj)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            textBox = obj;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
        }


        [FindsBy(How = How.Id, Using = "com.karabas:id/btn_place")]
        protected IWebElement place;

        [FindsBy(How = How.XPath, Using = "//android.support.v7.app.ActionBar$Tab[0]/android.widget.TextView")]
        protected IWebElement about_event;

        [FindsBy(How = How.Name, Using = "Full description")]
        protected IWebElement description;

        [FindsBy(How = How.Id, Using = "com.karabas:id/back")]
        protected IWebElement back;

        [FindsBy(How = How.Id, Using = "com.karabas:id/tv_name")]
        protected IWebElement name;

        [FindsBy(How = How.Id, Using = "com.karabas:id/tv_when")]
        protected IWebElement date;

        public string DescriptionClick()
        {
            description.Click();
            try
            {
                return date.Text;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public void PlaceClick()
        {
            place.Click();
        }
        public string Name()
        {
            return name.Text;
        }
        public string Date()
        {
            return date.Text;
        }
        public void Back()
        {
            back.Click();
        }
    }
}
