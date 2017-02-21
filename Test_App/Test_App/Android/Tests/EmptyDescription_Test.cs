using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_App.Android.Pages;

namespace Test_App.Android.Tests
{
    class EmptyDescription_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public EmptyDescription_Test(AndroidDriver<IWebElement> dri, TextBox obj) : base(dri, obj)
        {
            driver = dri;
            textBox = obj;
        }

        public override void GoTest()
        {
            string lname = "";
            string name;
            int count = 0;
            string path = @"C:\Users\sashu\Desktop\Empty Description Test";
            try
            {
                AndroidEventPage event_page;
                SliderViewClick();
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                MonthClick(6);
                for (int i = 1; ; i++)
                {
                    //if (i == 1)
                    //{
                    //    for (int j = 0; j < 30; j++)
                    //    {
                    //        driver.FindElementsByXPath("//android.widget.RelativeLayout[@resource-id=\"com.karabas:id/root\"]");
                    //        driver.Swipe(350, 400, 350, 1100, 400);
                    //        count++;
                    //    }
                    //}

                    event_page = EventsListItemClick();
                    name = event_page.Name() + "_" + event_page.Date();
                    name = name.Replace(".", "_");
                    name = name.Replace(",", "_");
                    name = name.Replace(" ", "_");
                    name = name.Replace(":", "_");
                    name = name.Replace("?", "_");

                    if (name == lname)
                    {
                        textBox.AppendText("Сделаны ScreenShots всех мероприятий в этом месяце!");
                        textBox.AppendText("Колличество Мероприятий -> " + i.ToString());
                        break;
                    }

                    string desc = event_page.DescriptionClick();
                    if(desc == "")
                    {
                        textBox.AppendText("Нет Описания Мероприятия: " + name + "\r\n");
                    }

                    lname = name;
                    event_page.Back();

                    driver.FindElementsByXPath("//android.widget.RelativeLayout[@resource-id=\"com.karabas:id/root\"]");
                    driver.Swipe(350, 400, 350, 1100, 400);
                    count++;
                }
            }
            catch (Exception e)
            {
                //textBox.AppendText(e.Message + "\r\n");
                File.AppendAllText(path + "\\EmptyDescription.txt", textBox.Text);
                MessageBox.Show("Тест Прерван!");
            }
            finally
            {
                textBox.AppendText("\r\n\r\n");
                textBox.AppendText("Всего Проверено  -  " + count.ToString() + "\r\n");
                MessageBox.Show("Тест Завершен!");
            }
        }
    }
}
