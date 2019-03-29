using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    // publikum se vytvoří prázdné a následně se k nemu přiřadí témata a podle témat se vyberou návštěvnící a přidají se do seznamu    
    public class Audience
    {
        string nameOfAudience { get; set; }
        List<string> interests { get; set; }
        List<Visitor> visitors { get; set; }

        public Audience(string nOa)
        {
            nameOfAudience = nOa;
        }
    }
}
