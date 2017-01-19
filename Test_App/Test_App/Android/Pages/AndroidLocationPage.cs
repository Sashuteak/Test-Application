using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System.Windows.Forms;

namespace Test_App.Android.Pages
{
    class AndroidLocationPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public AndroidLocationPage(AndroidDriver<IWebElement> dri, TextBox textBox)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            this.textBox = textBox;
        }

        [FindsBy(How = How.Id, Using = "com.karabas:id/fl_country")]
        private IWebElement country;

        [FindsBy(How = How.Id, Using = "com.karabas:id/fl_city")]
        private IWebElement city;

        [FindsBy(How = How.Id, Using = "com.karabas:id/btn_ok")]
        private IWebElement buttton_ok;

        [FindsBy(How = How.Id, Using = "com.karabas:id/close")]
        private IWebElement close;


        public void CunntryClick()
        {
            country.Click();
        }
        public void CityClick()
        {
            city.Click();
            textBox.AppendText("Step To -> City Choise \r\n");
        }
        public void ButtonOkClick()
        {
            textBox.AppendText("Step To -> " + buttton_ok.GetAttribute("name") + "\r\n");
            buttton_ok.Click();
        }
        public void CloseClick()
        {
            close.Click();
        }
    }
}
