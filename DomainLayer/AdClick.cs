using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class AdClick
    {
        public int clickIDOF { get; set; }
        public Ad ad { get; set; }
        public Visitor visitor { get; set; }
        public DateTime clicked { get; set; }
    }
}
