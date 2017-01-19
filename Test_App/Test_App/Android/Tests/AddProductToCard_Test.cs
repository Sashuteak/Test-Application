using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class AddProductToCard_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public AddProductToCard_Test(AndroidDriver<IWebElement> dri, TextBox textBox) : base(dri, textBox)
        {
            this.textBox = textBox;
            this.driver = dri;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }


        public override void GoTest()
        {
            AndroidStorePage store = StoreClick();
            string pn = store.product_name.Text;
            int price = GetMethods.GetElementNumb(store.product_price);
            BuyProductPAge buy = store.СhooseProduct(1);
            if(pn == buy.product_name.Text)
            {
                textBox.AppendText("Выбранный товар соответствует товару на странице покупки \r\n");
            }
            else
            {
                textBox.AppendText("Выбранный товар НЕсоответствует товару на странице покупки \r\n");
            }

            buy.SetCountField("2");
            buy.SubmitBuy();

            if (driver.FindElementById("com.karabas:id/tv_basket_count").Text == "2")
            {
                textBox.AppendText("Колличество выбраных товоров соответствует колличеству товаров в корзине \r\n");
            }
            else
            {
                textBox.AppendText("Колличество выбраных товоров НЕсоответствует колличеству товаров в корзине \r\n");
            }
            BasketPage bask = BasketClick();

            if(pn == bask.name_text.Text)
            {
                textBox.AppendText("Выбранный товар соответствует товару в корзине \r\n");
            }
            else
            {
                textBox.AppendText("Выбранный товар НЕсоответствует товару в корзине \r\n");
            }

            int bask_price = GetMethods.GetElementNumb(bask.basket_price);

            if ((price * 2) == bask_price)
            {
                textBox.AppendText("цена за товар указана верно \r\n");
            }
            else
            {
                textBox.AppendText("цена за товар указана НЕверно \r\n");
            }

            bask.RemoveProduct();

            driver.PressKeyCode(AndroidKeyCode.Back);
            EventsClick();
        }
    }
}
