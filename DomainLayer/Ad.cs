using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    class Ad
    {
        int adId { get; set; }
        string targetUrl { get; set; }
        string title { get; set; }
        string longTitle { get; set; }
        string description { get; set; }
        string companyName { get; set; }
        int nOfViews { get; set; }
        AdGroup adGroup { get; set; }
        WebPage webPage { get; set; }
        AdImage adImage { get; set; }
    }
}
