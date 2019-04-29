using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class InInterest
    {
        public int inInterestID { get; set; }
        public Interest interest { get; set; }
        public Category category { get; set; }
    }
}
