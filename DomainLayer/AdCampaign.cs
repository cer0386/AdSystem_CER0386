using System;
using System.Collections.Generic;

namespace DomainLayer
{
    public class AdCampaign
    {
        int campaignId { get; set; }
        string type { get; set; }
        Byte status { get; set; }
        double budget { get; set; }
        double cpm { get; set; }
        DateTime start { get; set; }
        DateTime ? end { get; set; } //? = nullable
        Company company { get; set; }
        List<AdGroup> adGroups { get; set; }

        public AdCampaign(int cI, string t, Byte s, double b, double cpm, DateTime st, Company c, AdGroup agr, DateTime ? e = null)
        {
            campaignId = cI;
            type = t;
            status = 1;
            budget = b;
            this.cpm = cpm;
            start = st;
            company = c;      
            end = e;
            adGroups.Add(agr);
        }

        
    }
}
