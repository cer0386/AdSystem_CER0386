using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    // publikum se vytvoří prázdné a následně se k nemu přiřadí témata a podle témat se vyberou návštěvnící a přidají se do seznamu    
    public class Audience
    {
        public int audienceID { get; set; }
        public string nameOfAudience { get; set; }
        public Interest interest { get; set; }
        public Category category { get; set; }
        public List<Visitor> visitors { get; set; }

    }
}
