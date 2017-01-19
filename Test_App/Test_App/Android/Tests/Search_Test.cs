using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class Search_Test : AndroidMainPage
    {
        TextBox textBox;
        AndroidDriver<IWebElement> driver;
        Sikuli4Net.sikuli_REST.Screen AndroidScreen;
        Pattern search, keyboard, language, clear, appiumlang;
        APILauncher launcher;
        public Search_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.textBox = textBox;
            launcher = new APILauncher(true);
            AndroidScreen = new Sikuli4Net.sikuli_REST.Screen();
            search = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\search.png"));
            keyboard = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\keyboard.png"));
            language = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\language.png"));
            clear = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\clearsearch.png"));
            appiumlang = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\appiumlang.png"));
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            launcher.Start();


            AndroidFilterPage filter = GoToFilter();
            string[] name = new string[filter.Categories.Count];
            for (int i = 0; i < filter.Categories.Count; i++)
            {
                name[i] = filter.Categories[i].Text;
            }
            filter.CloseClick();
            SearchClick();
            for (int i = 0; i < name.Length; i++)
            {
                SetSearchField(name[i]);
                ClickSearchField();

                AndroidScreen.Wait(keyboard, 30);
                AndroidScreen.Click(keyboard);
                AndroidScreen.Wait(language, 30);
                AndroidScreen.Click(language);

                AndroidScreen.Wait(search, 30);
                AndroidScreen.Click(search);

                textBox.AppendText(name[i] + "  -  " + driver.FindElementByXPath("//android.widget.LinearLayout[@resource-id=\"com.karabas:id/ll\"]/android.widget.TextView[@resource-id=\"com.karabas:id/tv_search\"]").Text + "\r\n");
                AndroidScreen.Wait(clear, 30);
                AndroidScreen.Click(clear);

                ClickSearchField();
                AndroidScreen.Wait(keyboard, 30);
                AndroidScreen.Click(keyboard);
                AndroidScreen.Wait(appiumlang, 30);
                AndroidScreen.Click(appiumlang);
            }

            AndroidScreen.Wait(clear, 30);
            AndroidScreen.Click(clear);
        }
    }
}
