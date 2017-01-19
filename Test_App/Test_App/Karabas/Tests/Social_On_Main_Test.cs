using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_App.Karabas.Pages;

namespace Test_App.Karabas.Tests
{
    class Social_On_Main_Test : Main_Page
    {
        private IWebDriver driver;
        private Info info;
        private DateTime date;
        private TextBox logs_info;
        private CheckMethods assert;
        private TextBox textBox1;

        public Social_On_Main_Test(IWebDriver driver, TextBox textbox, TextBox textbox2) : base(driver)
        {
            this.driver = driver;
            info = new Info(driver, textbox);
            date = info.InitDate();
            logs_info = textbox2;
            assert = new CheckMethods(textbox);
            textBox1 = textbox;
        }
        public override void GoTest()
        {
            textBox1.Clear();

            vk.Click();
            textBox1.AppendText(vk.Text + "\r\n");
            info.Show();

            fb.Click();
            textBox1.AppendText(fb.Text + "\r\n");
            info.Show();

            inst.Click();
            textBox1.AppendText(inst.Text + "\r\n");
            info.Show();

            ActionMethods.GoToMainPage(driver);

            info.Time(date);
            info.getLogs(logs_info);
            info.Save("Проверка Вкладок Партнерам");
        }
    }
}
