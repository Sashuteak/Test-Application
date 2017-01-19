using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Test_App.Karabas.Pages
{
    public class Account_Page
    {
        //Все Элементы Профиля Из Выпадающего Списка На Главной Странице
        //[FindsBy(How = How.CssSelector, Using = ".user-account")]
        //public IWebElement user_drop_down;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"my-account\"]")]
        public IWebElement my_account;
        [FindsBy(How = How.CssSelector, Using = ".user-logout")]
        public IWebElement exit;

        //Все Элементы Главной Страници Профиля
        [FindsBy(How = How.CssSelector, Using = ".my-accoynt")]
        public IWebElement my_profile;
        [FindsBy(How = How.CssSelector, Using = ".my-tickets")]
        public IWebElement my_tickets;
        [FindsBy(How = How.CssSelector, Using = "span[class=user-logout]")]
        public IWebElement user_logout;

        //Все Элементы Вкладки "Мой профиль"
        [FindsBy(How = How.Id, Using = "profile-sirname")]
        public IWebElement last_name_field;
        [FindsBy(How = How.Id, Using = "profile-name")]
        public IWebElement first_name_field;
        [FindsBy(How = How.Id, Using = "user-mail")]
        public IWebElement email_field;
        [FindsBy(How = How.Id, Using = "user-phone")]
        public IWebElement phone_field;
        [FindsBy(How = How.CssSelector, Using = ".button-yellow")]
        public IWebElement save_button;

        //Все Элементы Вкладки "Активные"
        [FindsBy(How = How.CssSelector, Using = ".my-active-tickets")]
        public IWebElement my_active_tickets;
        [FindsBy(How = How.CssSelector, Using = "#profile-ticket input[type=\"text\"]")]
        public IWebElement active_barcode_field;
        [FindsBy(How = How.CssSelector, Using = "#profile-ticket button[type=\"submit\"]")]
        public IWebElement active_submit;

        //Все Элементы Вкладки "В архиве"
        [FindsBy(How = How.CssSelector, Using = ".my-archive-tickets")]
        public IWebElement my_archive;
        [FindsBy(How = How.CssSelector, Using = "#profile-inactive-ticket input[type=\"text\"]")]
        public IWebElement archive_barcode_field;
        [FindsBy(How = How.CssSelector, Using = "#profile-inactive-ticket button[type=\"submit\"]")]
        public IWebElement archive_submit;


        public Account_Page(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }
    }
}
