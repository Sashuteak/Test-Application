﻿using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class Hall_ScreenShots : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public Hall_ScreenShots(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.textBox = textBox;
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            string lname = "";
            string name;
            int count = 0;
            try
            {
                AndroidEventPage event_page;
                SliderViewClick();
                MonthClick(3);
                for (int i = 1; ; i++)
                {
                    if (i == 1)
                    {
                        for (int j = 0; j < 165; j++)
                        {
                            driver.FindElementsByXPath("//android.widget.RelativeLayout[@resource-id=\"com.karabas:id/root\"]");
                            driver.Swipe(350, 400, 350, 1100, 300);
                            count++;
                        }
                    }

                    event_page = EventsListItemClick();
                    name = event_page.Name() + "_" + event_page.Date();
                    name = name.Replace(".", "_");
                    name = name.Replace(",", "_");
                    name = name.Replace(" ", "_");
                    name = name.Replace(":", "_");
                    name = name.Replace("?", "_");

                    if (name == lname)
                    {
                        textBox.AppendText("Сделаны ScreenShots всех мероприятий в этом месяце!");
                        textBox.AppendText("Колличество Мероприятий -> " + i.ToString());
                        break;
                    }

                    textBox.AppendText(i.ToString() + ". Name -> " + name + "\r\n");
                    event_page.PlaceClick();
                    driver.FindElementById("com.karabas:id/iv_hall");

                    driver.TakeScreenshot().SaveAsFile(@"C:\Users\sashu\Desktop\ScreenShot\" + name + ".png", ImageFormat.Png);
                    lname = name;
                    driver.PressKeyCode(AndroidKeyCode.Back);
                    event_page.Back();

                    driver.FindElementsByXPath("//android.widget.RelativeLayout[@resource-id=\"com.karabas:id/root\"]");
                    driver.Swipe(350, 400, 350, 1100, 400);
                    count++;
                }
            }
            catch (Exception e)
            {
                textBox.AppendText(e.Message + "\r\n");
                MessageBox.Show("Тест Прерван!");
            }
            finally
            {
                textBox.AppendText("\r\n\r\n");
                textBox.AppendText("Всего Сделано ScreenPicture  -  " + count.ToString() + "\r\n");
                MessageBox.Show("Тест Завершен!");
            }
        }
     }
}