using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LiqPayTest
{
    class LiqPay : PaymentSystemBase
    {
        readonly string URL = "https://www.liqpay.com/api/request";
        readonly string Public_Key = "i7786373972";
        readonly string Private_Key = "sJN71jgupuz5BRQiR6cvN2tlh9E0aJrdxXA3eieJ1da0";

        public override void GetOrders(DateTime From, DateTime To = default(DateTime))
        {
            if (To == default(DateTime))
                To = DateTime.Now;

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("version", "3");
            param.Add("public_key", Public_Key);
            param.Add("action", "reports");
            param.Add("date_from", GetMilliseconds(From).ToString());
            param.Add("date_to", GetMilliseconds(To).ToString());
            string data = EncodeTo64(JsonConvert.SerializeObject(param));
            string signature = Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(Private_Key + data + Private_Key)));
            string RequestString = String.Format($"data={data}&signature={signature}");

            var res = JObject.Parse(Request(URL, RequestString));
            var list = res["data"];
            foreach (var item in list)
            {
                try
                {
                    Orders.Add(item["order_id"].ToString(), new BasicOrder(item["order_id"].ToString(), item["status"].ToString(), item["amount"].ToString()));
                }
                catch (ArgumentException) { }
            }
        }
    }
}
