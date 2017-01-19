﻿using OpenQA.Selenium;
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
    class Registration_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public Registration_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.textBox = textBox;
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }

        public override void GoTest()
        {
            AndroidNavigatePage nav = NavigateClick();
            AndroidLoginPage log = nav.ProfileClick();
            AndroidRegistrationPage reg = log.RegClick();

            reg.SetFNAme("Василий");
            reg.SetLName("Пупкин");
            reg.SetPhone("+380937658949");
            reg.SetEmail("Pupkin@gmail.com");
            reg.SubmitClick();
        }
    }
}