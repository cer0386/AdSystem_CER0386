using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class WebPage
    {
        public int webPageID { get; set; }
        public string url { get; set; }
        public string product { get; set; }
        public Category category { get; set; }
    }
}
