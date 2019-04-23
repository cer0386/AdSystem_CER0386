using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class AdView
    {
        public int viewIDOF { get; set; }
        public Ad ad { get; set; }
        public Visitor visitor { get; set; }
        public DateTime viewed { get; set; }
    }
}
