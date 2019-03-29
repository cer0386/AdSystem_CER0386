using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Ad
    {
        int adId { get; }
        string targetUrl { get; set; }
        string title { get; set; }
        string longTitle { get; set; }
        string description { get; set; }
        string companyName { get; set; }
        int nOfViews { get; set; }
        AdGroup adGroup { get; set; }
        WebPage webPage { get; set; }
        AdImage adImage { get; set; }


        public Ad(int adI, string tU, string t, string lT, string d, string cN, int nov, AdGroup aG, WebPage wP, AdImage adIm = null)
        {
            adId = adI;
            targetUrl = tU;
            title = t;
            longTitle = lT;
            description = d;
            companyName = cN;
            nOfViews = nov;
            adGroup = aG;
            webPage = wP;
            adImage = adIm;
        }

        private void showAd()
        {

        }
    }
}
