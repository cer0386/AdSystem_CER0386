using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class WebPage
    {
        string url { get; set; }
        string category { get; set; }
        string product { get; set; }

        public WebPage(string u, string c, string p = null)
        {
            url = u;
            category = c;
            product = p;
        }
    }
}
