using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System;
using System.IO;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class BuyTicket_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        Sikuli4Net.sikuli_REST.Screen BuyTicket;
        Pattern testButton, cardfield, date, crv, submit, assert, pay, emailfield, confirmemail;
        APILauncher launcher;
        public BuyTicket_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.textBox = textBox;
            this.driver = dri;
            launcher = new APILauncher(true);
            BuyTicket = new Sikuli4Net.sikuli_REST.Screen();
            testButton = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\fan_002.png"));
            cardfield = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\cardfield_002.png"));
            date = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\date_002.png"));
            crv = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\crv_002.png"));
            submit = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\submit.png"));
            assert = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\assert_001.png"));
            pay = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\pay_001.png"), 0.6);
            emailfield = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\emailfield.png"));
            confirmemail = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"AndroidImages\confirmemail.png"));

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            launcher.Start();
            AndroidFilterPage filter = GoToFilter();
            filter.ScrollToDate();
            DatePage dp = filter.DateToClick();
            dp.PickYearClick();
            dp.ScrollUntil("2030");

            filter.DateFromClick();
            dp.PickYearClick();
            dp.ScrollUntil("2029");

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            filter.ScrollToDate();
            filter.SubmitClick();

            driver.FindElementsByXPath("//android.widget.RelativeLayout[@resource-id=\"com.karabas:id/root\"]");
            driver.Swipe(350, 400, 350, 1100, 300);

            driver.FindElementsByClassName("android.widget.RelativeLayout");
            driver.Swipe(350, 300, 350, 1100, 800);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            driver.FindElementById("com.karabas:id/root").Click();
            driver.FindElementById("com.karabas:id/btn_place").Click();

            BuyTicket.Wait(testButton, 30);
            BuyTicket.Click(testButton);

            driver.FindElementById("com.karabas:id/btn_to_basket").Click();
            driver.FindElementById("com.karabas:id/ll_basket").Click();

            driver.FindElementById("com.karabas:id/btn_make_order").Click();
            driver.FindElementById("com.karabas:id/btn_pay").Click();

            string card = "5457 0822 3709 2726";
            BuyTicket.Wait(cardfield, 30);
            BuyTicket.Type(cardfield, card, KeyModifier.NONE);

            BuyTicket.Wait(date, 30);
            BuyTicket.Type(date, "0720", KeyModifier.NONE);

            BuyTicket.Wait(crv, 30);
            BuyTicket.Type(crv, "474", KeyModifier.NONE);

            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Zero);
                driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().className(\"android.webkit.WebView\")).scrollForward();"));
            }
            catch { }

            BuyTicket.Wait(submit, 30);
            BuyTicket.Click(submit);

            BuyTicket.Wait(pay, 50);
            BuyTicket.Click(pay);

            BuyTicket.Wait(emailfield, 30);
            BuyTicket.Type(emailfield, "sashuteak@gmail.com", KeyModifier.NONE);

            BuyTicket.Wait(confirmemail, 30);
            BuyTicket.Click(confirmemail);

            try
            {
                if (BuyTicket.Exists(assert, 20))
                {
                    textBox.AppendText("Тест Пройтед Успешно");
                }
                else
                {
                    throw new Exception("Тест Провален");
                }
            }
            catch (Exception e)
            {
                textBox.AppendText(e.Message);
            }
            finally
            {
                driver.CloseApp();
            }
        }
    }
}
