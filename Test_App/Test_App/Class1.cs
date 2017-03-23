using LiqPayTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_App
{
    public partial class Form1 : Form
    {
        CheckerManager check_manager;
        private void button13_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            if (comboBox4.SelectedItem.ToString() == "LiqPay")
            {
                richTextBox4.Text = check_manager.GetAllOrdersLiqPay().ToString();
                var status = check_manager.LiqPay.Orders.Select(x => x.Value.Status).Distinct();
                foreach (var item in status)
                {
                    comboBox5.Items.Add(item);
                }
            }
            else if (comboBox4.SelectedItem.ToString() == "WayForPay")
            {
                richTextBox4.Text = check_manager.GetAllOrdersWayForPay().ToString();
                var status = check_manager.WayForPay.Orders.Select(x => x.Value.Status).Distinct();
                foreach (var item in status)
                {
                    comboBox5.Items.Add(item);
                }
            }
            else if (comboBox4.SelectedItem.ToString() == "Frontmanager")
            {
                richTextBox4.Text = check_manager.GetAllOrdersWayFrontmanager().ToString();
                var status = check_manager.Frontmanager.Orders.Select(x => x.Value.Status).Distinct();
                foreach (var item in status)
                {
                    comboBox5.Items.Add(item);
                }
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "LiqPay")
            {
                richTextBox4.Text = check_manager.LiqPay.GetOrderByID(textBox5.Text);
            }
            else if (comboBox4.SelectedItem.ToString() == "WayForPay")
            {
                richTextBox4.Text = check_manager.WayForPay.GetOrderByID(textBox5.Text);
            }
            else if (comboBox4.SelectedItem.ToString() == "Frontmanager")
            {
                richTextBox4.Text = check_manager.Frontmanager.GetOrderByID(textBox5.Text);
            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox4.Clear();
            if (comboBox4.SelectedItem.ToString() == "LiqPay")
            {
                var res = check_manager.LiqPay.Orders.Where(x => x.Value.Status == comboBox5.SelectedItem.ToString());
                foreach (var item in res)
                {
                    richTextBox4.AppendText(item.Value + "\n");
                }
                richTextBox4.AppendText("Total Count: " + res.Count());
            }
            else if (comboBox4.SelectedItem.ToString() == "WayForPay")
            {
                var res = check_manager.WayForPay.Orders.Where(x => x.Value.Status == comboBox5.SelectedItem.ToString());
                foreach (var item in res)
                {
                    richTextBox4.AppendText(item.Value + "\n");
                }
                richTextBox4.AppendText("Total Count: " + res.Count());
            }
            else if (comboBox4.SelectedItem.ToString() == "Frontmanager")
            {
                var res = check_manager.Frontmanager.Orders.Where(x => x.Value.Status == comboBox5.SelectedItem.ToString());
                foreach (var item in res)
                {
                    richTextBox4.AppendText(item.Value + "\n");
                }
                richTextBox4.AppendText("Total Count: " + res.Count());
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            
            if (comboBox4.SelectedItem.ToString() == "LiqPay")
            {
                richTextBox5.Text = check_manager.CheckWithLiqPay().ToString();
            }
            else if (comboBox4.SelectedItem.ToString() == "WayForPay")
            {
                richTextBox5.Text = check_manager.CheckWithWayForPay().ToString();
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            check_manager = new CheckerManager(dateTimePicker1.Value, dateTimePicker2.Value);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "LiqPay")
            {
                richTextBox5.Text = check_manager.UnexistingOrdersLiqPay().ToString();
            }
            else if (comboBox4.SelectedItem.ToString() == "WayForPay")
            {
                richTextBox5.Text = check_manager.UnexistingOrdersWayForPay().ToString();
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "LiqPay")
            {
                richTextBox5.Text = check_manager.ExistingOrdersLiqPay().ToString();
            }
            else if (comboBox4.SelectedItem.ToString() == "WayForPay")
            {
                richTextBox5.Text = check_manager.ExistingOrdersWayForPay().ToString();
            }
        }
    }
}
