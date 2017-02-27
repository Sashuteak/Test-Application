using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_App.Help_Class;

namespace Test_App
{
    //Orders Check Tad Page
    public partial class Form1 : Form
    {
        string path1;
        string path2;

        Microsoft.Office.Interop.Excel.Application app;
        Workbook xlWorkBook;
        Worksheet xlWorkSheet;
        Range range;

        List<Source> src;
        List<Result> result;
        IEnumerable<Source> sample;

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog exc = new OpenFileDialog();
            if (exc.ShowDialog() == DialogResult.OK)
            {
                path1 = exc.FileName;
                path2 = @"..\..\Excel Files\" + Path.GetFileName(path1);
                if (!File.Exists(path2))
                    File.Copy(path1, path2);

                comboBox2.Items.Add(Path.GetFileName(path2));
                comboBox2.SelectedIndex = 0;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string buf = comboBox2.SelectedItem.ToString();
            xlWorkBook = app.Workbooks.Open(Path.GetFullPath(@"..\..\Excel Files\" + buf), 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            src = new List<Source>();
            progressBar2.Maximum = range.Rows.Count;
            progressBar2.Minimum = 0;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                src.Add(new Source(range[i, 17].Text, range[i, 2].Text, range[i, 13].Text));
                progressBar2.Value += 1;
                System.Windows.Forms.Application.DoEvents();
            }          
            foreach (var item in src)
            {
                richTextBox1.AppendText(item.ToString());
                System.Windows.Forms.Application.DoEvents();
            }
            progressBar1.Value = 0;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            int count = 1;
            sample = src.Where(x => x.Status == textBox6.Text);
            foreach (var item in sample)
            {
                richTextBox1.AppendText(count + ". " + item.ToString());
                count++;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string path = @"https://arm.frontmanager.com.ua/OrderCardWA?order=";
            Regex regex1 = new Regex(@"\d{1,20}");
            MatchCollection matches3;
            List<string> orders = new List<string>();
            result = new List<Result>();
            foreach (var item in sample)
            {
                matches3 = regex1.Matches(item.OrderId);
                if (matches3.Count > 0)
                {
                    foreach (Match match in matches3)
                    {
                        orders.Add(match.Value);
                    }
                }
            }

            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Url = "https://arm.frontmanager.com.ua/";
            Driver.FindElement(By.Id("inLogin")).SendKeys("a.Levchenko");
            Driver.FindElement(By.Id("inPwd")).SendKeys("Jesus is way");
            Driver.FindElement(By.Id("doLogin")).Click();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            Driver.FindElement(By.ClassName("username")).Click();



            int k = 1;
            for (int i = 0; i < orders.Count; i++)
            {
                var check = src.Where(s => s.OrderId.Contains(orders[i]));
                Driver.Url = path + orders[i];
                string status = "";
                List<IWebElement> RadioButton = Driver.FindElements(By.Name("orderStatus")).ToList();
                List<IWebElement> Label = Driver.FindElements(By.TagName("label")).ToList();
                foreach (var item in RadioButton)
                {
                    if(item.Selected)
                    {
                        IWebElement text = Label.Where(s => s.GetAttribute("for") == item.GetAttribute("id")).SingleOrDefault();
                        status = text.Text;
                        break;
                    }
                }

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
                result.Add(new Result(orders[i], ch.Status, status));
                richTextBox2.AppendText($"OrderID: {orders[i]}\r\nStatus LiqPay: {ch.Status}\r\nStatus FrontManager: {status}\r\n\r\n");
                //if (x - y == decimal.Parse(ch.Price.Replace('.', ',')))
                //{
                //    richTextBox2.AppendText(k + ". Заказ Прошел Проверку - " + orders[i] + "\r\n");
                //}
                //else
                //{
                //    richTextBox2.AppendText(k + ". Заказ Не Прошел Проверку - " + orders[i] + "\r\n");
                //}              
                k++;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            string selected = comboBox3.SelectedItem.ToString().Trim();
            var res = result.Where(r => r.FMStatus == selected);
            if(res.Count() == 0)
            {
                richTextBox2.Text = "Ничего не найдено!";
                return;
            }
            foreach (var item in res)
            {
                richTextBox2.AppendText(item.ToString());
            }
        }
    }
}
