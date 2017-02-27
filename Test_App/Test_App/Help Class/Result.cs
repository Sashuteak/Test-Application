using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App.Help_Class
{
    public class Result
    {
        public string OrderId { get; set; }
        public string LiqPayStatus { set; get; }
        public string FMStatus { get; set; }

        public Result(string order, string liqStatus, string fmStatus)
        {
            OrderId = order;
            LiqPayStatus = liqStatus;
            FMStatus = fmStatus;
        }
        public override string ToString()
        {
            return String.Format($"OrderID: {OrderId}\r\nStatus LiqPay: {LiqPayStatus}\r\nStatus FrontManager: {FMStatus}\r\n\r\n");
        }
    }
}
