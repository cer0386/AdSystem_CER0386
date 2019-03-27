using System;

namespace DomainLayer
{
    public class AdCampaign
    {
        int campaignId { get; set; }
        string type { get; set; }
        bool status { get; set; }
        double budget { get; set; }
        double cpm { get; set; }
        DateTime start { get; set; }
        DateTime end { get; set; }
        Company company { get; set; }
    }
}
