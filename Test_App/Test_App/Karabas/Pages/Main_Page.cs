using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Threading;

namespace Test_App.Karabas.Pages
{
    abstract class Main_Page
    {
        IWebDriver driver;

        public Main_Page(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
            this.driver = browser;
        }

        //Авторизация
        [FindsBy(How = How.CssSelector, Using = "button.user-login")]
        private IWebElement authorization;


        //Выбор Городов
        [FindsBy(How = How.CssSelector, Using = "#content button.dd-trigger")]
        public IWebElement all_citys;
        [FindsBy(How = How.XPath, Using = ".//*[@id='content']//fieldset[1]/div[1]/ul/li/label")]
        public IList<IWebElement> citys;


        //Элементы Поиска
        [FindsBy(How = How.XPath, Using = ".//*[@id='field-query']")]
        public IWebElement search_field;
        [FindsBy(How = How.CssSelector, Using = ".query-params")]
        public IWebElement search_options;
        [FindsBy(How = How.CssSelector, Using = ".button-border.query-submit")]
        public IWebElement search_submit;
        
        //Корзина
        [FindsBy(How = How.CssSelector, Using = ".icon-cart")]
        public IWebElement cart;


        //Мультиязычность
        [FindsBy(How = How.CssSelector, Using = ".is-active")]
        public IWebElement language_drop_down;
        [FindsBy(How = How.CssSelector, Using = "#language li[data-url=\"en-gb\"]")]
        public IWebElement en;
        [FindsBy(How = How.CssSelector, Using = "#language li[data-url=\"ru-ru\"]")]
        public IWebElement ru;
        [FindsBy(How = How.CssSelector, Using = "#language li[data-url=\"uk-ua\"]")]
        public IWebElement ua;


        //Соц Сети
        [FindsBy(How = How.CssSelector, Using = (".follow-block a.s-vk"))]
        public IWebElement vk;
        [FindsBy(How = How.CssSelector, Using = (".follow-block a.s-fb"))]
        public IWebElement fb;
        [FindsBy(How = How.CssSelector, Using = (".follow-block a.s-inst"))]
        public IWebElement inst;


        //Элементы Подписки
        [FindsBy(How = How.CssSelector, Using = "input[name=\"email\"]")]
        public IWebElement subscribe_field;
        [FindsBy(How = How.CssSelector, Using = ".half-col button[type=\"submit\"]")]
        public IWebElement subscribe_submit;


        //Избранные
        [FindsBy(How = How.CssSelector, Using = ".fave-link")]
        public IWebElement favorite;


        //Обратная связь
        [FindsBy(How = How.CssSelector, Using = ".foot-left li a")]
        public IList<IWebElement> Feedback { get; set; }


        //Навигация Header
        [FindsBy(How = How.CssSelector, Using = ".quick-query>a")]
        public IList<IWebElement> head_nav { get; set; }


        //События
        [FindsBy(How = How.XPath, Using = ".//*[@id='footer']/div/div[2]/div[1]/div[1]/ul/li/a")]
        public IList<IWebElement> Developments;
        //Сервисы
        [FindsBy(How = How.XPath, Using = ".//*[@id='footer']/div/div[2]/div[1]/div[2]/ul/li/a")]
        public IList<IWebElement> Services;
        //О Нас
        [FindsBy(How = How.XPath, Using = ".//*[@id='footer']/div/div[2]/div[2]/div[1]/ul/li/a")]
        public IList<IWebElement> About;
        //Спецпредложения
        [FindsBy(How = How.XPath, Using = ".//*[@id='footer']/div/div[2]/div[2]/div[2]/ul/li/a")]
        public IList<IWebElement> Specials;
        //Партнерам
        [FindsBy(How = How.XPath, Using = ".//*[@id='footer']/div/div[2]/div[2]/div[3]/ul/li/a")]
        public IList<IWebElement> Partners;

        public abstract void GoTest();
        public Login_Page Authorization()
        {
            authorization.Click();
            Thread.Sleep(1000);
            return new Login_Page(driver);
        }
    }
}
