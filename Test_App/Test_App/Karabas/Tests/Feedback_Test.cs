using OpenQA.Selenium;
using Test_App.Karabas.Pages;
using System.Windows.Forms;
using System;
using NUnit.Framework;

namespace Test_App.Karabas.Tests
{
    class Feedback_Test : Main_Page
    {
        private IWebDriver driver;
        private Info info;
        private DateTime date;
        private TextBox logs_info;
        private CheckMethods assert;
        private TextBox textbox1;

        public Feedback_Test(IWebDriver browser, TextBox textbox, TextBox textbox2) : base(browser)
        {
            this.driver = browser;
            info = new Info(driver, textbox);
            date = info.InitDate();
            logs_info = textbox2;
            assert = new CheckMethods(textbox);
            textbox1 = textbox;
        }
        public override void GoTest()
        {
            textbox1.Clear();
            for (int i = 0; i < Feedback.Count; i++)
            {
                Feedback[i].Click();
                assert.IsTextPresent(driver.FindElement(By.CssSelector("#content>h1")), Feedback[i].Text);
                info.Show();
            }
            ActionMethods.GoToMainPage(driver);

            info.Time(date);
            info.getLogs(logs_info);
            info.Save("Проверка Вкладок - Обратная Связь");
        }
    }
}
