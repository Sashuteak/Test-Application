using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class AddProductToFavorite_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public AddProductToFavorite_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.textBox = textBox;
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            AndroidStorePage store = StoreClick();

            driver.FindElementsByClassName("android.widget.FrameLayout");
            driver.Swipe(350, 450, 350, 1000, 500);

            store.AddToFavorit();

            string pn = store.product_name.Text;
            textBox.AppendText("Вы добавили в Избранное -> "+pn+" \r\n");

            store.GoTOProductFAvorite();

            string pn2 = driver.FindElementByXPath("//android.support.v4.view.ViewPager//android.widget.TextView").Text;

            if (pn == pn2)
            {
                textBox.AppendText("Добавленный товар в Избранные - соответствует товару в Избранных \r\n");
            }
            else
            {
                textBox.AppendText("Добавленный товар в Избранные - НЕсоответствует товару в Избранных \r\n");
            }

            store.AddToFavorit();
            EventsClick();
        }
    }
}
