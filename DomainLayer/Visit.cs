using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Visit
    {
        public int visitIDOF { get; set; }
        public Visitor visitor { get; set; }
        public WebPage webPage { get; set; }
        public DateTime? visited { get; set; }
    }
}
