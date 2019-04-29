using System;
using System.Collections.Generic;


namespace DomainLayer
{
    public class AdCampaign
    {
        public int campaignId { get; set; }
        public string name { get; set; }
        public CampaignType campaignType { get; set; }
        public bool status { get; set; }
        public double budget { get; set; }
        public double costPer { get; set; }
        public DateTime start { get; set; }
        public DateTime ? ending { get; set; } //? = nullable
        public Company company { get; set; }
        public List<AdGroup> adGroups { get; set; }
        

        
    }
}
