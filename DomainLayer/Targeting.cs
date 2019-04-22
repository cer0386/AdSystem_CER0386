using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Targeting
    {
        public int targetingId { get; set; }
        public string interest { get; set; }
        public string category { get; set; }
        public string product { get; set; }

        public Targeting(int tI, string i = null, string c = null, string p = null)
        {
            targetingId = tI;
            interest = i;
            category = c;
            product = p;
        }
    }
}
