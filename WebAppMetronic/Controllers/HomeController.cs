using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMetronic.Controllers
{
    public class HomeController : Controller
    {
        private List<AdCampaign> campaigns;
        private int nOfClicks { get; set; }
        AdCampaignMapper adCmapper = new AdCampaignMapper();
        int companyID=12345677;
        // GET: Home
        public ActionResult Index()
        {
            nOfClicks = 400;
            ViewBag.nOfClicks = nOfClicks;
            return View(campaigns);
        }
        public HomeController()
        {
            campaigns = adCmapper.FindAdCampaigns(companyID);
        }

    }
}