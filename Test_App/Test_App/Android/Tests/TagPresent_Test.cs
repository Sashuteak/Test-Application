using System;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using Test_App.Android.Pages;
using System.IO;


//Check For Git Hub
namespace Test_App.Android.Tests
{
    class TagPresent_Test : AndroidMainPage
    {
        AndroidDriver<IWebElement> driver;
        TextBox textBox;
        public TagPresent_Test(AndroidDriver<IWebElement> dri, TextBox obj) : base(dri, obj)
        {
            driver = dri;
            textBox = obj;
        }

        public override void GoTest()
        {
            string lname = "";
            string name;
            int count = 0;
            string path = @"C:\Users\sashu\Desktop\TagDescription_Test";
            try
            {
                AndroidEventPage event_page;
                SliderViewClick();
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                //MonthClick(2);
                for (int i = 1; ; i++)
                {
                    if (i == 1)
                    {
                        for (int j = 0; j < 25; j++)
                        {
                            driver.FindElementsByXPath("//android.widget.RelativeLayout[@resource-id=\"com.karabas:id/root\"]");
                            driver.Swipe(350, 400, 350, 1100, 300);
                            count++;
                        }
                    }

                    event_page = EventsListItemClick();
                    name = event_page.Name() + "_" + event_page.Date();
                    name = name.Replace(".", "_");
                    name = name.Replace(",", "_");
                    name = name.Replace(" ", "_");
                    name = name.Replace(":", "_");
                    name = name.Replace("?", "_");

                    if (name == lname)
                    {
                        textBox.AppendText("Проверено Мероприятий На Наличие Тегов -> " + i.ToString());
                        break;
                    }

                    textBox.AppendText(i.ToString() + ". Имя Мероприятия -> " + name + "\r\n");
                    string desc = event_page.DescriptionClick();
                    for (int j = 0; j < desc.Length; j++)
                    {
                        if(desc[j] == '<')
                        {
                            for (int k = 0; k < desc.Length; k++)
                            {
                                if (desc[k] == '>')
                                {
                                    textBox.AppendText("В Описании Присутствуют Теги!\r\n\r\n");
                                    break;
                                }
                            }
                            break;
                        }
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
                textBox.AppendText(e.Message + "\r\n");
                File.AppendAllText(path + "\\TagPresent.txt", textBox.Text);
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
