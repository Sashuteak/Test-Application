using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiqPayTest
{
    class WayForPay : PaymentSystemBase
    {
        readonly string URL = "https://api.wayforpay.com/api";
        readonly string Public_Key = "karabas_com";
        readonly string Private_Key = "7c2d19bf0dfc78ce28570507c4927ef3f0119b4d";

        public override void GetOrders(DateTime From, DateTime To = default(DateTime))
        {
            if (To == default(DateTime))
                To = DateTime.Now;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("apiVersion", 1);
            param.Add("transactionType", "TRANSACTION_LIST");
            param.Add("merchantAccount", Public_Key);
            param.Add("merchantSignature", HMAC_MD5(Private_Key, String.Format($"{Public_Key};{GetSeconds(From)};{GetSeconds(To)}")));
            param.Add("dateBegin", GetSeconds(From));
            param.Add("dateEnd", GetSeconds(To));

            string data = JsonConvert.SerializeObject(param);
            var res = JObject.Parse(Request(URL, data));
            var list = res["transactionList"];
            long expDate = 0;
            foreach (var item in list)
            {
                if(Orders.Keys.Contains(item["orderReference"].ToString()))
                {
                    if (expDate < (long)item["processingDate"])
                    {
                        Orders.Remove(item["orderReference"].ToString());
                        Orders.Add(item["orderReference"].ToString(), new BasicOrder(item["orderReference"].ToString(), item["transactionStatus"].ToString(), item["amount"].ToString()));
                    }
                }
                else
                {
                    Orders.Add(item["orderReference"].ToString(), new BasicOrder(item["orderReference"].ToString(), item["transactionStatus"].ToString(), item["amount"].ToString()));
                    expDate = (long)item["processingDate"];
                }
            }
        }
    }
}
