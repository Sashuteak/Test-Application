using System;
using System.Windows.Forms;
using OpenQA.Selenium;
using Test_App.Karabas.Pages;
using OpenQA.Selenium.Support.UI;
using SikuliModule;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System.Drawing;
using System.IO;

namespace Test_App.Karabas.Tests
{
    class Login_Test : Main_Page
    {
        private IWebDriver driver;
        private Info info;
        private DateTime date;
        private TextBox logs_info;
        private CheckMethods assert;
        private Account_Page account;
        private TextBox textbox1;

        public Login_Test(IWebDriver browser, TextBox textBox1, TextBox textBox2) : base(browser)
        {
            this.driver = browser;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            info = new Info(driver, textBox1);
            date = info.InitDate();
            logs_info = textBox2;
            assert = new CheckMethods(textBox1);
            account = new Account_Page(driver);
            textbox1 = textBox1;
        }
        public override void GoTest()
        {
            //textbox1.Clear();
            //Login_Page login = Authorization();
            //login.Login("0936759070");

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".user-account"))).Click();

            //account.my_account.Click();
            //info.Show();
            //account.my_active_tickets.Click();
            //account.my_archive.Click();
            //account.user_logout.Click();

            //info.Time(date);
            //info.getLogs(logs_info);
            //info.Save("Проверка Авторизации");

            Sikuli4Net.sikuli_REST.Screen loginPage = new Sikuli4Net.sikuli_REST.Screen();

            Pattern testButton = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\test.png"));
            Pattern search = new Pattern(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Images\search.png"));

            loginPage.Wait(search);
            loginPage.Type(search, "Vasy Pupkin", KeyModifier.NONE);

            loginPage.Wait(testButton);
            loginPage.Click(testButton);
        }
    }
}
