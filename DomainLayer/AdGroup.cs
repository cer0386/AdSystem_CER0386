using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class AdGroup
    {
        int adGroupId { get; set; }
        string adGroupName { get; set; }
        Byte adGroupStatus { get; set; }
        double adGroupBudget { get; set; }
        double adGroupCPM { get; set; }
        int requiredViews { get; set; }
        List<Ad> ads { get; set; }
        Targeting targeting { get; set; }

        public AdGroup(int agI, string aGn, Byte aGs, double aGb, double aGcpm, int rV, Ad ad, Targeting t = null)
        {
            adGroupId = agI;
            adGroupName = aGn;
            adGroupBudget = aGb;
            adGroupCPM = aGcpm;
            requiredViews = rV;
            ads.Add(ad);
            targeting = t;
        }
    }
}
