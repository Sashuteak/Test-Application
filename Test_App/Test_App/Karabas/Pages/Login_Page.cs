using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace Test_App.Karabas.Pages
{
    public class Login_Page
    {
        public Login_Page(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        //Элементы Входа
        [FindsBy(How = How.Id, Using = ("user-phone"))]
        public IWebElement phone_field;
        [FindsBy(How = How.XPath, Using = ".//*[@id='auth-form']/button[3]")]
        public IWebElement login_submit;
        [FindsBy(How = How.CssSelector, Using = ".social a[class=\"s-vk\"]")]
        private IWebElement vk_login;
        [FindsBy(How = How.CssSelector, Using = ".social a[class=\"s-fb\"]")]
        private IWebElement fb_login;


        //Элементы Регистрации
        [FindsBy(How = How.CssSelector, Using = "button[data-href=\"sign\"]")]
        public IWebElement register_button;
        [FindsBy(How = How.CssSelector, Using = "#user-phone")]
        private IWebElement reg_phone_field;
        [FindsBy(How = How.CssSelector, Using = "#user-name")]
        private IWebElement reg_name_field;
        [FindsBy(How = How.CssSelector, Using = "#user-mail")]
        private IWebElement reg_email_field;
        [FindsBy(How = How.XPath, Using = ".//*[@id='auth-form']/button[2]")]
        private IWebElement reg_submit;
        [FindsBy(How = How.CssSelector, Using = "#popup-auth i[class=\"icon-clear\"]")]
        public IWebElement reg_close { get; set; }


        //Методы Обработки Элементов
        public void Login(string phone)
        {
            phone_field.Click();
            phone_field.SendKeys(phone);
            login_submit.Click();
        }
        public void Registration(string phone, string name, string email)
        {
            register_button.Click();
            reg_phone_field.Click();
            reg_phone_field.SendKeys(phone);
            reg_name_field.SendKeys(name);
            reg_email_field.SendKeys(email);
            reg_submit.Click();
        }
    }
}
