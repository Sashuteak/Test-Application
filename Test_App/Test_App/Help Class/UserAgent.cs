using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App.Help_Class
{
    public class UserAgent
    {
        public string Agent { get; set; }
        public string Os { set; get; }
        public string Device { get; set; }

        public UserAgent(string agent, string os, string device)
        {
            Agent = agent;
            Os = os;
            Device = device;
        }
    }
}
