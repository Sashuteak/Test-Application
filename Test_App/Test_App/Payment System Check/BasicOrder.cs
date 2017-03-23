using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiqPayTest
{
    class BasicOrder
    {
        public string OrderID { get; set; }
        public string Status { get; set; }
        public string Price { get; set; }
        public BasicOrder(string order, string status, string price)
        {
            OrderID = order;
            Status = status;
            Price = price;
        }
        public override string ToString()
        {
            return String.Format($"Order ID: {OrderID}\nStatus: {Status}\nPrice: {Price}\n");
        }
    }
}
