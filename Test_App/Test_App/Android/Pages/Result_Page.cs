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
    class Result_Page
    {
        TextBox textBox;
        AndroidDriver<IWebElement> driver;
        public Result_Page(AndroidDriver<IWebElement> dri, TextBox obj)
        {
            PageFactory.InitElements(dri, this);
            this.driver = dri;
            textBox = obj;
        }

        [FindsBy(How = How.XPath, Using = "//android.support.v4.view.ViewPager/android.widget.RelativeLayout/android.widget.LinearLayout[2]/android.widget.TextView")]
        public IWebElement search_result { get; set; }
    }
}
