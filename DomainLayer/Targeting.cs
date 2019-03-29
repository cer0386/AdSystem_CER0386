using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    class Targeting
    {
        int targetingId { get; set; }
        string interest { get; set; }
        string category { get; set; }
        string product { get; set; }

        public Targeting(int tI, string i = null, string c = null, string p = null)
        {
            targetingId = tI;
            interest = i;
            category = c;
            product = p;
        }
    }
}
