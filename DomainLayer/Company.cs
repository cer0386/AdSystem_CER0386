using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Company
    {
        int crn { get; set; }
        string companyName { get; set; }
        bool vip { get; set; }

        public Company(int c, string cN, bool v)
        {
            crn = c;
            companyName = cN;
            vip = v;
        }
    }
}
