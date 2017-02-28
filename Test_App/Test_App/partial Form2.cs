using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UAParser;

namespace Test_App
{
    //User Agent Tab Page
    public partial class Form1 : Form
    {
        Parser uaParser;
        Microsoft.Office.Interop.Excel.Application xlApp;

        //Exel parser for user agent
        private void button3_Click(object sender, EventArgs e)
        {
            uaParser = Parser.GetDefault();
            List<Help_Class.UserAgent> agents = new List<Help_Class.UserAgent>();

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(Path.GetFullPath(@"D:\Sashuteak\Test_App\Test_App\Test_App\UserAgents\visitordataUserAgentFebruary.xls"), 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;

            string str;
            progressBar3.Maximum = range.Rows.Count;
            progressBar3.Minimum = 0;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                str = (string)(range.Cells[i, 1] as Range).Value2;
                str.Trim();
                var c = uaParser.Parse(str);
                agents.Add(new Help_Class.UserAgent(c.UA.ToString(), c.OS.ToString(), c.Device.ToString()));
                progressBar3.Value += 1;
            }

            var res = agents.GroupBy(x => x.Agent);
            foreach (var item in res)
            {
                richTextBox3.AppendText($"AGENT : {item.Key.ToUpper()}\r\n");
                var tmp = from w in item
                          group w by w.Os into OsCount
                          select new { Os = OsCount.Key, Count = OsCount.Count() };

                foreach (var item2 in tmp)
                {
                    richTextBox3.AppendText($"  Os : {item2.Os}     Count: {item2.Count}\r\n");
                }
                richTextBox3.AppendText("\r\n");
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            uaParser = Parser.GetDefault();
            var c = uaParser.Parse(textBox7.Text);
            string parse = String.Format($"Agent: {c.UA}    Система: {c.OS}   Устройство: {c.Device}");
            textBox8.Text = parse;
        }
    }
}
