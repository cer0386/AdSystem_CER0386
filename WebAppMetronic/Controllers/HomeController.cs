using DataLayer;
using DomainLayer;
using DomainLayer.HelpClasses;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Highsoft.Web.Mvc.Charts;
using System.Linq;

namespace WebAppMetronic.Controllers
{
    public class HomeController : Controller
    {
        AdCampaign adCampaign;
        DateTime from, to;
        private List<AdCampaign> campaigns;
        private int nOfClicks { get; set; }
        AdCampaignMapper adCmapper = new AdCampaignMapper();
        CampaignTypeMapper campaignTypeMapper = new CampaignTypeMapper();
        AdGroupMapper adGroupMapper = new AdGroupMapper();
        AdMapper adMapper = new AdMapper();
        string nameC;
        //zatím napevno bez loginu
        int companyID=12345677;

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.campaigns = campaigns;
            getSummary();
            from = new DateTime(2019, 5, 1);
            to = new DateTime(2019, 5, 31);

            List<GraphDataViews> dataViews = new AdCampaignMapper().FindViewsG(from, to);
            List<GraphDataClicks> dataClicks = new AdCampaignMapper().FindClicksG(from, to);
            List<DateTime> dateTimes = GetDates(from.Year, from.Month);
            List<int> views = new List<int>();
            List<int> clicks = new List<int>();

            int j=0 ,k = 0;
            for (int i = 0; i < dateTimes.Count-1; i++)
            {
                //list 
                if(dateTimes[i] == dataViews[j].date)
                {
                    views.Add(dataViews[j].views);
                    j++;
                }
                else
                {
                    views.Add(0);
                }
                if(dateTimes[i] == dataClicks[k].date)
                {
                    clicks.Add(dataClicks[k].clicks);
                    k++;
                }
                else
                {
                    clicks.Add(0);
                }
            }
            List<LineSeriesData> vData = new List<LineSeriesData>();
            List<LineSeriesData> cData = new List<LineSeriesData>();

            views.ForEach(p => vData.Add(new LineSeriesData { Y = p }));
            clicks.ForEach(p => cData.Add(new LineSeriesData { Y = p }));

            ViewData["views"] = vData;
            ViewData["clicks"] = cData;
            
            return View();
        }
        public HomeController()
        {
            //najdu všechny kampaně
            campaigns = adCmapper.FindAdCampaigns(companyID);
            foreach(AdCampaign c in campaigns)
            {
                c.campaignType = campaignTypeMapper.FindCampaignType(c.campaignType.campaignTypeID);
                c.views = adCmapper.FindNoViews(c.campaignId);
                c.clicks = adCmapper.FindNoClicks(c.campaignId);
                c.ctr = getCTR(c.views, c.clicks);
            }
        }
        public ActionResult Audience()
        {
            return View();
        }
        public ActionResult DetailGroup(int acID)
        {

            ViewBag.Name = acID;
            adCampaign = adCmapper.FindAdCampaign(acID);
            adCampaign.adGroups = new AdGroupMapper().FindAdGroups(adCampaign.campaignId);

            foreach(AdGroup adGroup in adCampaign.adGroups)
            {
                adGroup.views = adGroupMapper.FindNoViews(adGroup.adGroupId);
                adGroup.clicks = adGroupMapper.FindNoClicks(adGroup.adGroupId);
                adGroup.ctr = getCTR(adGroup.views, adGroup.clicks);
            }
            getGroupSummary();
            ViewBag.campaign = adCampaign;
            nameC = adCampaign.name;
            return View();
        }

        public ActionResult DetailAd(int agID)
        {
            AdGroup adGroup = adGroupMapper.FindAdGroup(agID);
            adGroup.ads = adMapper.FindAds(adGroup.adGroupId);
            foreach (Ad ad in adGroup.ads)
            {
                ad.views = adMapper.FindNoViews(ad.adId);
                ad.clicks = adMapper.FindNoClicks(ad.adId);
                ad.ctr = getCTR(ad.views, ad.clicks);
            }
            getAdSummary(adGroup);
            ViewBag.campaignN = nameC;
            ViewBag.adGroup = adGroup;
            return View();
        }

        private void getSummary()
        {
            double budgetA = 0;
            int viewsA = 0, clicksA = 0;
            foreach (AdCampaign adCa in campaigns)
            {
                viewsA += adCa.views;
                clicksA += adCa.clicks;
                budgetA += adCa.budget;
            }

            ViewBag.viewsA = viewsA;
            ViewBag.clicksA = clicksA;
            ViewBag.budgetA = budgetA;
            ViewBag.ctrA = getCTR(viewsA, clicksA);
        }
        private double getCTR(int views, int clicks)
        {
            double ctr = 0;
            if(clicks > 0 && views > 0)
            {
                double ctrA = (double)clicks / views * 100;
                ctr = Math.Round(ctrA, 2);
            }
            
            return ctr;
        }

        private void getGroupSummary()
        {
            double budgetA = 0;
            int viewsA = 0, clicksA = 0, rviewsA =0;
            foreach (AdGroup adCa in adCampaign.adGroups)
            {
                viewsA += adCa.views;
                clicksA += adCa.clicks;
                budgetA += adCa.adGroupBudget;
                rviewsA += adCa.requiredViews;
            }

            ViewBag.viewsA = viewsA;
            ViewBag.clicksA = clicksA;
            ViewBag.budgetA = budgetA;
            ViewBag.ctrA = getCTR(viewsA, clicksA);
            ViewBag.rviewsA = rviewsA;
        }

        private void getAdSummary(AdGroup adGroup)
        {
            int viewsA = 0, clicksA = 0;
            foreach (Ad adCa in adGroup.ads)
            {
                viewsA += adCa.views;
                clicksA += adCa.clicks;
            }


            ViewBag.viewsA = viewsA;
            ViewBag.clicksA = clicksA;
            ViewBag.ctrA = getCTR(viewsA, clicksA);

        }
        private static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }
    }
}