using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App.Server_Requests
{

    public class GetBuildingTypes
    {
        public string CommandStatus { get; set; }
        public string rows { get; set; }
        public ListTypes[] list { get; set; }
    }

    public class ListTypes
    {
        public string id { get; set; }
        public string name { get; set; }
    }

}
