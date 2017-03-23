using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace LiqPayTest
{
    abstract class PaymentSystemBase
    {
        public Dictionary<string, BasicOrder> Orders { get; set; }
        public PaymentSystemBase()
        {
            Orders = new Dictionary<string, BasicOrder>();
        }
        public enum Status : byte
        {
            Reserve, // Резерв
            Success, // Оплачен
            Canceled, // Отменен
            Pending, // В Ожидании Оплаты
            Return, // Возврат
            Implementation = 6 // В Реализации
        }

        //Методы
        abstract public void GetOrders(DateTime From, DateTime To = default(DateTime));
        public string GetOrderByID(string id)
        {
            return Orders[id].ToString();
        }
        protected long GetMilliseconds(DateTime obj)
        {
            DateTime dt = TimeZoneInfo.ConvertTimeToUtc(obj);
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan tsInterval = dt.Subtract(dt1970);
            return Convert.ToInt64(tsInterval.TotalMilliseconds);
        }
        protected long GetSeconds(DateTime obj)
        {
            DateTime dt = TimeZoneInfo.ConvertTimeToUtc(obj);
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan tsInterval = dt.Subtract(dt1970);
            return Convert.ToInt64(tsInterval.TotalSeconds);
        }
        protected string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }
        protected string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("x2");
            }
            return (sbinary);
        }
        protected string HMAC_MD5(string key, string src)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(key);

            HMACMD5 hmacmd5 = new HMACMD5(keyByte);
            byte[] messageBytes = encoding.GetBytes(src);
            byte[] hashmessage = hmacmd5.ComputeHash(messageBytes);
            return ByteToString(hashmessage);
        }
        protected string GetStatus(byte op)
        {
            switch(op)
            {
                case (byte)Status.Reserve:
                    return Status.Reserve.ToString();
                case (byte)Status.Success:
                    return Status.Success.ToString();
                case (byte)Status.Canceled:
                    return Status.Canceled.ToString();
                case (byte)Status.Pending:
                    return Status.Pending.ToString();
                case (byte)Status.Return:
                    return Status.Return.ToString();
                case (byte)Status.Implementation:
                    return Status.Implementation.ToString();
            }
            return "";
        }
        protected string Request(string Url, string Data)
        {
            // Отправка POST Запроса 
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] byteArray = Encoding.UTF8.GetBytes(Data);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // Получение ответа от сервера
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string StringResponse = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();
            return StringResponse;
        }
    }
}
