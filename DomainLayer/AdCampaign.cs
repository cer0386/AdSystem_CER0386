using System;
using System.Collections.Generic;

namespace DomainLayer
{
    public class AdCampaign
    {
        int campaignId { get; set; }
        string type { get; set; }
        bool status { get; set; }
        double budget { get; set; }
        double costPer { get; set; }
        DateTime start { get; set; }
        DateTime ? ending { get; set; } //? = nullable
        Company company { get; set; }
        List<AdGroup> adGroups { get; set; }



        
    }
}
