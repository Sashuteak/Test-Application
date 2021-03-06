﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App.Help_Class
{
    public class Source
    {
        public string OrderId { get; set; }
        public string Price { set; get; }
        public string Status { get; set; }

        public Source(string order, string price, string status)
        {
            OrderId = order;
            Price = price;
            Status = status;
        }
        public override string ToString()
        {
            return String.Format($"{OrderId} - {Status} - {Price}\r\n");
        }
    }
}
