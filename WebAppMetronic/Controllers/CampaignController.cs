using DataLayer;
using DomainLayer;
using DomainLayer.HelpClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMetronic.Controllers
{
    public class CampaignController : Controller
    {
        CampaignTypeMapper cMapper = new CampaignTypeMapper();
        List<CampaignType> campaignTypes = new List<CampaignType>();
        AdCampaignMapper adCampaignMapper = new AdCampaignMapper();
        AdGroupMapper adGroupMapper = new AdGroupMapper();
        CampaignTypeMapper campaignTypeMapper = new CampaignTypeMapper();
        AdMapper adMapper = new AdMapper();
        AdCampaign adCampaign = new AdCampaign();
        AdGroup adGroup = new AdGroup();
        Ad ad = new Ad();
        int companyID = 12345677;
        CultureInfo culture = new CultureInfo("en-US");

        // GET: Campaign
        public ActionResult NewCampaign()
        {
            campaignTypes = cMapper.FindCampaignTypes();
            ViewBag.Types = campaignTypes;
            
            return View();
        }

        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult ccc()
        {
            return View();
        }

        public CampaignController()
        {
            
        }

        [HttpPost]
        public ActionResult NewCampaign(FormCollection collection, string type)
        {
            adCampaign.campaignType = new CampaignType();
            adCampaign.campaignType.campaignTypeID = Int32.Parse(collection[1]);
            adCampaign.name = collection[2];
            adCampaign.status = true;
            adCampaign.company = new Company();
            adCampaign.company.crn = companyID;
            adCampaign.budget = Double.Parse(collection[3]);
            adCampaign.costPer = Double.Parse(collection[4]);
            adCampaign.start = Convert.ToDateTime(collection[5], culture);
            if(collection[6] != null && collection[6] != "")
                adCampaign.ending = Convert.ToDateTime(collection[6], culture);
            AdCampaignMapper.Insert(adCampaign);

            adGroup.adCampaign = new AdCampaign();
            adGroup.adCampaign.campaignId = adCampaignMapper.FindAdCampaignMaxID();
            adGroup.adGroupName = collection[7];
            if (collection[8] != null && collection[8] != "")
                adGroup.adGroupBudget = Double.Parse(collection[8]);
            if (collection[9] != null && collection[9] != "")
                adGroup.maxCostPer = Double.Parse(collection[9]);
            adGroup.requiredViews = Int32.Parse(collection[10]);
            AdGroupMapper.Insert(adGroup);

            ad.adGroup = new AdGroup();
            ad.adGroup.adGroupId = adGroupMapper.FindAdGroupMaxID();
            ad.targetUrl = collection[11];
            ad.title = collection[12];
            ad.longTitle = collection[13];
            ad.description = collection[14];
            ad.companyName = collection[15];
            try
            {
                


                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        
    }
}