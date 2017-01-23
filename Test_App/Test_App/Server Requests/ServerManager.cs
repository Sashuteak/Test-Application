using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Test_App.Server_Requests
{
    class ServerManager
    {
        public string Url { get; set; }
        public string Auth { get; set; }
        public List<string> list;

        TextBox textbox;
        ProgressBar pb;

        public ServerManager(TextBox textbox, ProgressBar p)
        {
            Url = "https://arm.frontmanager.com.ua/";
            Auth = "4a8d8d2424514feea04def767ead58b4HlJS3az4Hn1BI5FF5qU2qaBo6ag=";
            this.textbox = textbox;
            this.pb = p;
            list = new List<string>();
            list.Add("GetHall");
            list.Add("GetCities");
            list.Add("GetEvents");
            list.Add("GetActualHalls");
            list.Add("GetBuildingTypes");
        }
        public void GetHall()
        {
            WebRequest req = WebRequest.Create(Url + "GetHalls.cmd?__auth={{" + Auth + "}}");
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            Rootobject root = JsonConvert.DeserializeObject<Rootobject>(Out);
            for (int i = 0; i < root.list.Length; i++)
            {
                textbox.AppendText(root.list[i].name + "\r\n");
            }
            textbox.AppendText("\r\nОбщее Кол-во -> " + root.list.Length.ToString());
        }
        public void GetCities()
        {
            WebRequest req = WebRequest.Create(Url + "GetCities.cmd?__auth={{" + Auth + "}}");
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            GetCitys root = JsonConvert.DeserializeObject<GetCitys>(Out);
            for (int i = 0; i < root.list.Length; i++)
            {
                textbox.AppendText(root.list[i].name + "\r\n");
            }
            textbox.AppendText("\r\nОбщее Кол-во -> " + root.list.Length.ToString());
        }
        public void GetEvents()
        {
            pb.Minimum = 0;
            pb.Value = 0;
            WebRequest req = WebRequest.Create(Url + "GetPartnerEventsCommand.cmd?__auth=" + Auth + "&from=2017/01/23");
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            GetEvents root = JsonConvert.DeserializeObject<GetEvents>(Out);
            pb.Maximum = root.Events.Length;
            int count = 0;
            int count2 = 0;
            for (int i = 0; i < root.Events.Length; i++)
            {
                //if(root.Events[i].ActivityDescriptionLong == "")
                //{
                //    textbox.AppendText(root.Events[i].ActivityName + "\r\n");
                //    textbox.AppendText(root.Events[i].EventDate.ToString() + "\r\n");
                //    textbox.AppendText("ID -> "+root.Events[i].EventId.ToString() + "\r\n");
                //    count++;
                //}
                //if (root.Events[i].ActivityDescriptionLong == "" && root.Events[i].ActivityDescriptionLongText == "" && root.Events[i].EventDescription == "" && root.Events[i].EventDescriptionText == "")
                //{
                //    textbox.AppendText(root.Events[i].ActivityName + "\r\n");
                //    textbox.AppendText(root.Events[i].EventDate.ToString() + "\r\n");
                //    textbox.AppendText("ID -> " + root.Events[i].EventId.ToString() + "\r\n\r\n");
                //    count2++;
                //}
                if(root.Events[i].ReplaceActivityDescription == "false")
                {
                    textbox.AppendText(root.Events[i].ActivityDescriptionLongText + "\r\n\r\n");
                    count2++;
                }
                if(root.Events[i].ReplaceActivityDescription == "true")
                {
                    textbox.AppendText(root.Events[i].EventDescriptionText + "\r\n\r\n");
                    count2++;
                }

                //pb.Value += 1;
            }
            textbox.AppendText("\r\nОбщее С Описанием -> " + count2.ToString());
            //textbox.AppendText("\r\nОбщее Кол-во без описания-> " + count2.ToString());
            textbox.AppendText("\r\nОбщее Кол-во -> " + root.Events.Length.ToString());
        }
        public void GetActualHalls()
        {
            WebRequest req = WebRequest.Create(Url + "GetPartnerEventsCommand.cmd?__auth=" + Auth + "&from=2017/01/23");
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            GetEvents root = JsonConvert.DeserializeObject<GetEvents>(Out);

            WebRequest req2 = WebRequest.Create(Url + "GetHalls.cmd?__auth={{" + Auth + "}}");
            WebResponse resp2 = req2.GetResponse();
            Stream stream2 = resp2.GetResponseStream();
            StreamReader sr2 = new StreamReader(stream2);
            string Hall = sr2.ReadToEnd();
            Rootobject root2 = JsonConvert.DeserializeObject<Rootobject>(Hall);



            int count = 0;
            List<string> list = new List<string>();
            for (int i = 0; i < root.Events.Length; i++)
            {
                for (int j = 0; j < root2.list.Length; j++)
                {
                    if (root.Events[i].HallId == root2.list[j].id)
                    {
                        textbox.AppendText(root2.list[j].name + "\r\n");
                        count++;
                        break;
                    }
                }
            }
            textbox.AppendText("\r\nОбщее Кол-во -> " + count.ToString());
        }
        public void GetBuildingTypes()
        {
            WebRequest req = WebRequest.Create(Url + "GetBuildingTypes.cmd?__auth={{" + Auth + "}}");
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            GetBuildingTypes root = JsonConvert.DeserializeObject<GetBuildingTypes>(Out);
            for (int i = 0; i < root.list.Length; i++)
            {
                textbox.AppendText(root.list[i].name + "\r\n");
            }
            textbox.AppendText("\r\nОбщее Кол-во -> " + root.list.Length.ToString());
        }
    }
}
