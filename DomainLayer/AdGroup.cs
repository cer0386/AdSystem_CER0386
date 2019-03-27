using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    class AdGroup
    {
        int adGroup { get; set; }
        string adGroupName { get; set; }
        bool adGroupStatus { get; set; }
        double adGroupBudget { get; set; }
        double adGroupCPM { get; set; }
        int requiredViews { get; set; }
        AdCampaign adCampaign { get; set; }
        Targeting targeting { get; set; }
    }
}
