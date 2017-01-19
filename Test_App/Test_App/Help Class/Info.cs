using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_App
{
    class Info
    {
        private IWebDriver driver;
        private TextBox textbox;

        public Info(IWebDriver browzer, TextBox obj)
        {
            this.driver = browzer;
            this.textbox = obj;
        }
        public void Show()
        {
            textbox.AppendText("Title  -  " + driver.Title + "\r\n");
            textbox.AppendText("Url  -  " + driver.Url + "\r\n");
            textbox.AppendText("\r\n");
        }
        public void Save(string test_name)
        {
            File.WriteAllText(@"C:\Users\sashu\Desktop\Test Report From Karabas\" + test_name + ".txt", textbox.Text);
        }
        public void Time(DateTime obj)
        {
            textbox.AppendText("\r\nВремя выполнения теста  -  " + DateTime.Now.Subtract(obj).ToString());
        }
        public DateTime InitDate()
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            return date;
        }
        public void getLogs(TextBox textbox2)
        {
            textbox2.Clear();
            var entries = driver.Manage().Logs.GetLog(LogType.Browser);
            int j = 0;
            foreach (var entry in entries)
            {
                textbox2.AppendText(entries[j].Message + "\r\n\r\n");
                j++;
            }
        }
    }
}
