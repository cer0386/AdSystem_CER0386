using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class AssignedExcluded
    {
        public int audienceIDOF { get; set; }
        public Audience audience { get; set; }
        public AdGroup adGroup { get; set; }
        //true assign, false exclude
        public bool action { get; set; }
    }
}
