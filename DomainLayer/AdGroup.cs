using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class AdGroup
    {
        public int adGroupId { get; set; }
        public string adGroupName { get; set; }
        public bool adGroupStatus { get; set; }
        public double adGroupBudget { get; set; }
        public double maxCostPer { get; set; }
        public int requiredViews { get; set; }
        public AdCampaign adCampaign { get; set; }
        public List<Ad> ads { get; set; }
        public List<Audience> audiences { get; set; }


    }
}
