using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Test_App.Karabas.Pages;

namespace Test_App.Karabas.Tests
{
    class Navigate_Test : Main_Page
    {
        private IWebDriver driver;
        private Info info;
        private DateTime date;
        private TextBox logs_info;
        private CheckMethods assert;
        private TextBox textBox1;

        public Navigate_Test(IWebDriver driver, TextBox textbox, TextBox textbox2) : base(driver)
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
            for (int i = 0; i < head_nav.Count; i++)
            {
                head_nav[i].Click();
                textBox1.AppendText(driver.FindElement(By.XPath(".//*[@id='content']/section[2]/div/span[2]/a/span")).Text + "\r\n");
                info.Show();
            }
            ActionMethods.GoToMainPage(driver);

            info.Time(date);
            info.getLogs(logs_info);
            info.Save("Проверка Навигации");
        }
    }
}
