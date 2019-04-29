using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Interest
    {
        public int interestID { get; set; }
        public string interestName { get; set; }
        public string description { get; set; }
        public List<Category> categories { get; set; }
    }
}
