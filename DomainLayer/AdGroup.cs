using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class AdGroup
    {
        public int adGroupId { get; set; }
        public string adGroupName { get; set; }
        public Byte adGroupStatus { get; set; }
        public double adGroupBudget { get; set; }
        public double adGroupCPM { get; set; }
        public int requiredViews { get; set; }
        public List<Ad> ads { get; set; }
        public Targeting targeting { get; set; }

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
