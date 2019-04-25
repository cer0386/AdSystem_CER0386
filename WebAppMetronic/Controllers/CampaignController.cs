using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMetronic.Controllers
{
    public class CampaignController : Controller
    {
        // GET: Campaign
        public ActionResult NewCampaign()
        {
            return View();
        }
    }
}