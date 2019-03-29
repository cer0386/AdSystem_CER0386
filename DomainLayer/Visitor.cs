using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Visitor
    {
        int visitorId { get; set; }
        string name { get; set; }
        string location { get; set; }

        public Visitor(int vI, string n = null, string l = null)
        {
            visitorId = vI;
            name = n;
            location = l;
        }
    }
}
