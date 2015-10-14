using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace WoopraPCL
{

    public class WoopraEvent
    {
        public WoopraEvent(string name)
        {
            Properties = new Dictionary<string, string>{ { "~event", name } };
        }

        public Dictionary<string, string> Properties { get; }
    }
}
