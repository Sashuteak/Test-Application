using System;
using OpenQA.Selenium;
using Test_App.Karabas.Pages;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Test_App.Karabas.Tests
{
    class Citys_Test : Main_Page
    {
        private IWebDriver driver;
        private Info info;
        private DateTime date;
        private TextBox logs_info;
        private CheckMethods assert;
        private TextBox textBox1;


        public Citys_Test(IWebDriver browser, TextBox textbox, TextBox textbox2) : base(browser)
        {
            this.driver = browser;
            info = new Info(driver, textbox);
            date = info.InitDate();
            logs_info = textbox2;
            assert = new CheckMethods(textbox);
            textBox1 = textbox;
        }

        public override void GoTest()
        {
            textBox1.Clear();
            for (int i = 1; i < citys.Count; i++)
            {
                Thread.Sleep(1000);
                all_citys.Click();
                citys[i].Click();
                Thread.Sleep(1000);
                textBox1.AppendText("Город  -  " + all_citys.Text + "\r\n");
                info.Show();
            }
            
            ActionMethods.GoToMainPage(driver);
            info.Time(date);
            info.getLogs(logs_info);
            info.Save("Проверка Выбора Всех Городов");
        }
    }
}
