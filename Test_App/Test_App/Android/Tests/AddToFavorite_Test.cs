using NUnit.Framework;
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
    class AddToFavorite_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public AddToFavorite_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.driver = dri;
            this.textBox = textBox;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            TableViewClick();
            FaveClick();
            string title1 = driver.FindElementById("com.karabas:id/tv_title").Text;
            textBox.AppendText("Event Must Be In Favorire -> " + title1 + "\r\n");
            FavoritePage fav_page = GoToFavorite();
            fav_page.GetTitle();
            FaveClick();
            fav_page.CloseFavorite();
        }
    }
}
