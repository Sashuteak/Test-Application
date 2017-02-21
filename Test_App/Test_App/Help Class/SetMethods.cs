using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Test_App.Android.Pages;
using Test_App.Android.Tests;
using Test_App.Karabas.Pages;

namespace Test_App
{
    static class SetMethods
    {
        public static List<AndroidMainPage> SetAndroidTests(AndroidDriver<IWebElement> driver2, TextBox textBox1)
        {
            List<AndroidMainPage> testlist = new List<AndroidMainPage>();

            testlist.Add(new Login_Test(driver2, textBox1));
            testlist.Add(new Registration_Test(driver2, textBox1));
            testlist.Add(new Search_Test(driver2, textBox1));
            testlist.Add(new AddToFavorite_Test(driver2, textBox1));
            testlist.Add(new ProfileNavigate_Test(driver2, textBox1));
            testlist.Add(new MainNavigate_Test(driver2, textBox1));
            testlist.Add(new Month_Test(driver2, textBox1));
            testlist.Add(new MenuNavigate_Test(driver2, textBox1));
            testlist.Add(new FilterCategories_Test(driver2, textBox1));
            testlist.Add(new DatePicker_Test(driver2, textBox1));
            testlist.Add(new CityPick_Test(driver2, textBox1));
            testlist.Add(new AddProductToCard_Test(driver2, textBox1));
            testlist.Add(new AddProductToFavorite_Test(driver2, textBox1));
            testlist.Add(new BuyTicket_Test(driver2, textBox1));
            testlist.Add(new Hall_ScreenShots(driver2, textBox1));
            testlist.Add(new TagPresent_Test(driver2, textBox1));
            testlist.Add(new EmptyDescription_Test(driver2, textBox1));
            return testlist;
        }
        public static List<Main_Page> SetWebTests(IWebDriver driver, TextBox textBox1, TextBox textBox2)
        {
            List<Main_Page> testlist = new List<Main_Page>();

            testlist.Add(new Karabas.Tests.Login_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.Registration_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.Feedback_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.Citys_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.Navigate_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.Developments_Footer_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.Service_Footer_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.About_Footer_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.Specials_Footer_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.Partners_Footer_Test(driver, textBox1, textBox2));
            testlist.Add(new Karabas.Tests.Social_On_Main_Test(driver, textBox1, textBox2));

            return testlist;
        }
        public static string RandEmail()
        {
            Random rand = new Random();
            string en = "abcdefghijklmnopqrstuvwxyz";
            string email = "";
            int size = rand.Next(6, 12);

            for (int i = 0; i < size; i++)
            {
                email = email + en[rand.Next(en.Length)];
            }
            email = email + "@mail.com";
            return email;
        }
        public static string RandPhone()
        {
            Random rand = new Random();
            string numb = "0123456789";
            string phone = "";

            for (int i = 0; i < 10; i++)
            {
                phone = phone + numb[rand.Next(10)];
            }
            return phone;
        }
        public static string RandName()
        {
            Random rand = new Random();
            string[] name = File.ReadAllLines(@"D:\Sashuteak\Test_App\Test_App\Test_App\TxtFiles\Name.txt");
            string res = name[rand.Next(0, name.Count())];
            return res;
        }
    }
}
