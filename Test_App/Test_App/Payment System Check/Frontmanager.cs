using Newtonsoft.Json.Linq;
using System;
using System.Threading;

namespace LiqPayTest
{
    class Frontmanager : PaymentSystemBase
    {
        readonly string URL = "https://arm.frontmanager.com.ua/GetOrdersCommand.cmd";
        readonly string URL2 = "https://arm.frontmanager.com.ua/GetExpiredOrdersCommand.cmd";
        readonly string Auth = "4ea1c40d5b394d01b8266a42fa21a9eaGD2ffrrKeqwlpUPkM5jY5cneK4w=";
        object locker = new object();

        public override void GetOrders(DateTime From, DateTime To = default(DateTime))
        {
            if (To == default(DateTime))
                To = DateTime.Now;

        
            string data = String.Format($"__auth={Auth}&dateFrom={From.Year}/{From.Month}/{From.Day}&dateTo={To.Year}/{To.Month}/{To.Day}&rows=100000");
            string response = Request(URL, data);
            string response2 = Request(URL2, data);

            Thread t = new Thread(delegate () { response = Request(URL, data); });
            t.Start();
            Thread t2 = new Thread(delegate () { response2 = Request(URL2, data); });
            t2.Start();
            
            Thread t3 = new Thread(ParseRespons);
            Thread t4 = new Thread(ParseRespons);

            while (true)
            {
                if (t.ThreadState == ThreadState.Stopped)
                {
                    t3.Start(response);
                    break;
                }
            }

            while (true)
            {
                if (t2.ThreadState == ThreadState.Stopped)
                {
                    t4.Start(response2);
                    break;
                }
            }
        }
        public void ParseRespons(object resp)
        {
            string response = (string)resp;
            lock(locker)
            {
                var res = JObject.Parse(response);
                var list = res["rows"];
                foreach (var item in list)
                {
                    try
                    {
                        Orders.Add(item["id"].ToString(), new BasicOrder(item["id"].ToString(), GetStatus((byte)item["Status"]), item["Total"].ToString()));
                    }
                    catch (Exception)
                    {

                        
                    }
                }
            }
        }
    }
}
