using System.Windows.Forms;
using OpenQA.Selenium;
using Test_App.Karabas.Pages;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace Test_App.Karabas.Tests
{
    class Registration_Test : Main_Page
    {
        private IWebDriver driver;
        private TextBox textBox1;
        private TextBox textBox2;
        private CheckMethods assert;
        private Info info;
        private DateTime date;
        public Registration_Test(IWebDriver driver, TextBox textBox1, TextBox textBox2) : base(driver)
        {
            this.driver = driver;
            this.textBox1 = textBox1;
            this.textBox2 = textBox2;
            assert = new CheckMethods(textBox1);
            info = new Info(driver, textBox1);
            date = info.InitDate();
        }

        public override void GoTest()
        {
            textBox1.Clear();
            Login_Page reg = Authorization();
            reg.Registration(SetMethods.RandPhone(), SetMethods.RandName(), SetMethods.RandEmail());
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            assert.IsTextPresent(wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".smsCode-field.smsCode>label"))), "Код из SMS:");
            reg.reg_close.Click();

            info.Time(date);
            info.getLogs(textBox2);
            info.Save("Проверка Регистрации");
        }
    }
}
