using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App.Server_Requests
{

    public class GetCitys
    {
        public string CommandStatus { get; set; }
        public string rows { get; set; }
        public ListCitys[] list { get; set; }
    }

    public class ListCitys
    {
        public string id { get; set; }
        public string name { get; set; }
        public string countryName { get; set; }
        public string countryId { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

}
