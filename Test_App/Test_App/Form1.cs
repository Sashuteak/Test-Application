using System;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Drawing;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using Test_App.Android.Pages;
using System.Collections.Generic;
using Test_App.Karabas.Pages;
using Test_App.Server_Requests;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using UAParser;
using System.Linq;
using System.Threading;
using Test_App.Help_Class;
using System.Text.RegularExpressions;

namespace Test_App
{
    public partial class Form1 : Form
    {
        IWebDriver Driver;
        ServerManager man;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            man = new ServerManager(textBox4, progressBar1);
            for (int i = 0; i < man.list.Count; i++)
            {
                comboBox1.Items.Add(man.list[i]);
            }
            comboBox1.SelectedIndex = 0;
            //Делаем форму круглой
            System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Form_Path.AddEllipse(7, 7, Start_Test.Width - 14, Start_Test.Height - 14);
            Region Form_Region = new Region(Form_Path);
            Start_Test.Region = Form_Region;

            System.Drawing.Drawing2D.GraphicsPath Delete = new System.Drawing.Drawing2D.GraphicsPath();
            Delete.AddEllipse(7, 6, button6.Width - 15, button6.Height - 13);
            Region Delete_Region = new Region(Delete);
            button6.Region = Delete_Region;

            System.Drawing.Drawing2D.GraphicsPath Refresh = new System.Drawing.Drawing2D.GraphicsPath();
            Refresh.AddEllipse(7, 5, button7.Width - 15, button7.Height - 14);
            Region Refresh_Region = new Region(Refresh);
            button7.Region = Refresh_Region;
        }

        //Отображение Названия Теста
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
            string name = listBox1.SelectedItem.ToString();
            textBox3.AppendText(name);
        }

        //Вывод Списка Доступных Тестов
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (radioButton1.Checked)
            {
                listBox1.Items.Add("1. Проверка Авторизации");
                listBox1.Items.Add("2. Проверка Регистрации");
                listBox1.Items.Add("3. Проверка Вкладок Обратная Связь");
                listBox1.Items.Add("4. Проверка Выбора Всех Городов");
                listBox1.Items.Add("5. Проверка Навигации");
                listBox1.Items.Add("6. Проверка Вкладок События");
                listBox1.Items.Add("7. Проверка Вкладок Сервисы");
                listBox1.Items.Add("8. Проверка Вкладок О Нас");
                listBox1.Items.Add("9. Проверка Вкладок Спецпредложения");
                listBox1.Items.Add("10. Проверка Вкладок Партнерам");
                listBox1.Items.Add("11. Проверка Соц Сетей на Главной");
                listBox1.Items.Add("12. Проверка Подписки");
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (radioButton2.Checked)
            {
                listBox1.Items.Add("1. Проверка Авторизации");
                listBox1.Items.Add("2. Проверка Регистрации");
                listBox1.Items.Add("3. Проверка Поиска По Категориям");
                listBox1.Items.Add("4. Проверка Вкладки Избранное");
                listBox1.Items.Add("5. Проверка Вкладок Профиля");
                listBox1.Items.Add("6. Проверка Вкладок На Главной Странице");
                listBox1.Items.Add("7. Проверка Навигации По Месяцам");
                listBox1.Items.Add("8. Проверка Навигации По Вкладкам Меню");
                listBox1.Items.Add("9. Проверка Работы Фильтра (Категории)");
                listBox1.Items.Add("10. Проверка Работы Фильтра (Date Picker)");
                listBox1.Items.Add("11. Проверка Работы Фильтра (Location)");
                listBox1.Items.Add("12. Проверка Добавления Товара в Корзину");
                listBox1.Items.Add("13. Проверка Добавления Товара в Избранные");
                listBox1.Items.Add("14. Проверка Полной Покупки Билета");
                listBox1.Items.Add("15. ScreenShots Отрисовок Залов");
                listBox1.Items.Add("16. Проверка Описаний На Наличие Тегов");
                listBox1.Items.Add("17. Проверка Присутствия Описаний");
            }
        }

        //События При Нажатии Определеной Кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);

            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            if (radioButton1.Checked)
            {
                Driver.Url = "http://test-karabas.com/";
                if (!Directory.Exists(@"C:\Users\sashu\Desktop\Test Report From Karabas"))
                    Directory.CreateDirectory(@"C:\Users\sashu\Desktop\Test Report From Karabas");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.Warning);
            IWebDriver Driver = new FirefoxDriver(options);
            Driver.Manage().Window.Maximize();

            if (radioButton1.Checked)
            {
                Driver.Url = "http://test-karabas.com/";
                if (!Directory.Exists(@"C:\Users\sashu\Desktop\Test Report From Karabas"))
                    Directory.CreateDirectory(@"C:\Users\sashu\Desktop\Test Report From Karabas");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Driver.Url = "http://test-karabas.com/";
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Срабатывает если выбран Karabas
            if(radioButton1.Checked)
            {
                this.SendToBack();
                List<Main_Page> testlist = new List<Main_Page>(SetMethods.SetWebTests(Driver, textBox1, textBox2));
                textBox1.Clear();
                testlist[listBox1.SelectedIndex].GoTest();
            }

            // Срабатывает если выбран Андроид
            if (radioButton2.Checked)
            {
                //Process process = new Process();
                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.WindowStyle = ProcessWindowStyle.Normal;
                //startInfo.FileName = "cmd.exe";
                //startInfo.Arguments = "/k (\"C:\\Program Files (x86)\\Appium\\node.exe\" \"C:\\Program Files (x86)\\Appium\\node_modules\\appium\\bin\\appium.js\" --address 127.0.0.1 --port 4723 --automation-name Appium --log-no-color";
                //process.StartInfo = startInfo;
                //process.Start();

                //process.Kill();

                AndroidDriver<IWebElement> AndroidDriver;
                DesiredCapabilities capp = new DesiredCapabilities();
                capp.SetCapability("deviceName", "Nexus4");
                capp.SetCapability("appPackage", "com.karabas");

                // Для реального девайса
                //capp.SetCapability("appActivity", "com.karabas.activities.SplashActivity");
                capp.SetCapability("appActivity", "com.karabas.activities.MainActivity");

                capp.SetCapability("platformName", "Android");
                //capp.SetCapability("unicodeKeyboard", "true");
                //capp.SetCapability("resetKeyboard", "true");


                AndroidDriver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capp);
                List<AndroidMainPage> testlist = new List<AndroidMainPage>(SetMethods.SetAndroidTests(AndroidDriver, textBox1));
                textBox1.Clear();
                testlist[listBox1.SelectedIndex].GoTest();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Driver.Quit();
        }


        //Отправление Запроса На Сервер
        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            int index = comboBox1.SelectedIndex;
            switch(index)
            {
                case 0:
                    man.GetHall();
                    break;
                case 1:
                    man.GetCities();
                    break;
                case 2:
                    man.GetEvents();
                    break;
                case 3:
                    man.GetActualHalls();
                    break;
                case 4:
                    man.GetBuildingTypes();
                    break;
            }
        }


        //Exel parser for user agent
        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"https://arm.frontmanager.com.ua/OrderCardWA?order=";
            List<Source> src = new List<Source>();

            Microsoft.Office.Interop.Excel.Application app2 = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkBook2;
            Worksheet xlWorkSheet2;
            Range range2;

            xlWorkBook2 = app2.Workbooks.Open(@"D:\Sashuteak\Test_App\Test_App\Test_App\liqpay.xls", 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet2 = (Worksheet)xlWorkBook2.Worksheets.get_Item(1);
            range2 = xlWorkSheet2.UsedRange;

            progressBar1.Maximum = range2.Rows.Count;
            progressBar1.Minimum = 0;

            for (int i = 1; i <= range2.Rows.Count; i++)
            {
                src.Add(new Source(range2[i, 17].Text, decimal.Parse(range2[i, 2].Text), range2[i, 13].Text));
                progressBar1.Value += 1;
            }
            progressBar1.Value = 0;

            //var reve = src.Where(s => s.Status == "reversed");
            //foreach (var item in reve)
            //{
            //    textBox1.AppendText(item.ToString() + "\r\n");
            //}

            xlWorkBook2.Close(true, null, null);
            app2.Quit();



            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;

            List<string> orders = new List<string>();
            xlWorkBook = app.Workbooks.Open(@"D:\Sashuteak\Test_App\Test_App\Test_App\expdata.xls", 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            progressBar1.Maximum = range.Rows.Count;
            progressBar1.Minimum = 0;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                orders.Add(range[i, 1].Text);
                progressBar1.Value += 1;
            }

            xlWorkBook.Close(true, null, null);
            app.Quit();

            progressBar1.Value = 0;
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Url = "https://arm.frontmanager.com.ua/";
            Driver.FindElement(By.Id("inLogin")).SendKeys("a.Levchenko");
            Driver.FindElement(By.Id("inPwd")).SendKeys("Jesus is way");
            Driver.FindElement(By.Id("doLogin")).Click();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            Thread.Sleep(30000);
            int k = 1;
            for (int i = 0; i < orders.Count; i++)
            {
                var check = src.Where(s => s.OrderId.Contains(orders[i]));
                if (check.Count() == 0)
                {
                    textBox2.AppendText(k + ". Перепроверить Заказ - " + orders[i] + "\r\n");
                }
                else
                {
                    
                    Driver.Url = path + orders[i];
                    string mainPrice = Driver.FindElement(By.XPath(".//*[@id='tabGeneral']/div[1]/div[2]/div[2]/p[1]")).Text.Replace('.', ',');
                    string bonusPrice = Driver.FindElement(By.XPath(".//*[@id='tabGeneral']/div[1]/div[2]/div[2]/p[3]/span")).Text.Replace('.', ',');

                    decimal x = 0;
                    decimal y = 0;
                    Regex regex = new Regex(@"\d{1,5}.\d{1,3}");
                    MatchCollection matches = regex.Matches(mainPrice);
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            x = decimal.Parse(match.Value.Replace('.', ','));
                        }
                            
                    }

                    MatchCollection matches2 = regex.Matches(bonusPrice);
                    if (matches2.Count > 0)
                    {
                        foreach (Match match in matches2)
                        {
                            y = decimal.Parse(match.Value.Replace('.', ','));
                        }
                         
                    }
                    var ch = check.First();
                    if (x - y == ch.Price)
                    {
                        textBox1.AppendText(k + ". Заказ Прошел Проверку - " + orders[i] + "\r\n");
                    }
                }
                k++;
            }


            //foreach (var item in orders)
            //{
            //    textBox2.AppendText(item + "\r\n");
            //}
            ////int coun = 1;
            ////bool check = false;
            ////progressBar1.Maximum = range2.Rows.Count + orders.Count + 100;
            ////progressBar1.Minimum = 0;
            ////for (int i = 0; i < 10; i++)
            ////{
            ////    for (int j = 1; j <= range2.Rows.Count; j++)
            ////    {
            ////        if (((string)range2[j, 17].Text).Contains(orders[i]))
            ////        {
            ////            textBox2.AppendText(coun.ToString() + ". " + (string)range2[j, 2].Text + "\r\n");
            ////            coun++;
            ////            check = true;
            ////            break;
            ////        }
            ////    }

            ////    if (check)
            ////    {
            ////        textBox1.AppendText(orders[i] + " - false\r\n");
            ////        check = false;
            ////    }
            ////    else
            ////    {
            ////        textBox1.AppendText(orders[i] + " - true\r\n");
            ////    }
            ////}



            //var uaParser = Parser.GetDefault();
            //List<UserAgent> agents = new List<UserAgent>();

            //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Workbook xlWorkBook;
            //Worksheet xlWorkSheet;
            //Range range;

            //xlWorkBook = xlApp.Workbooks.Open(@"D:\Sashuteak\Test_App\Test_App\Test_App\visitordataUserAgentFebruary.xls", 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //range = xlWorkSheet.UsedRange;

            //string str;
            //for (int i = 1; i <= range.Rows.Count; i++)
            //{
            //    for (int j = 1; j <= range.Columns.Count; j++)
            //    {
            //        str = (string)(range.Cells[i, j] as Range).Value2;
            //        str.Trim();
            //        var c = uaParser.Parse(str);
            //        agents.Add(new UserAgent(c.UA.ToString(), c.OS.ToString(), c.Device.ToString()));
            //    }
            //}

            //var res = agents.GroupBy(x => x.Agent);
            //foreach (var item in res)
            //{
            //    textBox5.AppendText($"AGENT : {item.Key.ToUpper()}\r\n");
            //    var res2 = item.Select(x => x.Os).Distinct();
            //    foreach (var item2 in res2)
            //    {
            //        textBox5.AppendText($"  Os : {item2}\r\n");
            //    }
            //}
            //xlWorkBook.Close(true, null, null);
            //xlApp.Quit();

            //Marshal.ReleaseComObject(xlWorkSheet);
            //Marshal.ReleaseComObject(xlWorkBook);
            //Marshal.ReleaseComObject(xlApp);
        }
    }
}