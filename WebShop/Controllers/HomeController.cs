using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {       
        AdGroup adG = new AdGroup();
        Ad adToShow = null;
        List<AdGroup> adGs = new List<AdGroup>();
        List<Interest> interests = new List<Interest>();

        string cat;
        List<Category> categories = new CategoryMapper().FindCategories();

        public ActionResult Index()
        {
            cat = ViewBag.Title;
            return View(categories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "O aplikaci.";
            cat = ViewBag.Title;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt.";

            return View();
        }

        public ActionResult cat1()
        {
            cat = ViewBag.Title;
            LoadAd();
            return View(categories);
        }

        public ActionResult cat2()
        {
            cat = ViewBag.Title;
            LoadAd();
            return View(categories);
        }
        public ActionResult cat3()
        {
            cat = ViewBag.Title;
            LoadAd();
            return View(categories);
        }
        public ActionResult cat4()
        {
            cat = ViewBag.Title;
            LoadAd();
            return View(categories);
        }
        public ActionResult cat5()
        {
            cat = ViewBag.Title;
            LoadAd();
            return View(categories);
        }

        public void LoadAd()
        {
            AudienceMapper audienceMapper = new AudienceMapper();
            InterestMapper interestMapper = new InterestMapper();
            CategoryMapper categoryMapper = new CategoryMapper();
            VisitorMapper visitorMapper = new VisitorMapper();
            //nalezení všech aktivních sestav
            List<AdGroup> adGs = new AdGroupMapper().FindActiveAdGroups();
            bool help = false;
            string cat = "Telefony";
            //kategorie webové stránky
            Category category = new CategoryMapper().FindCategory(cat);

            //cílení podle obsahu stránky
            //nalezení publik u sestav
            foreach (AdGroup ag in adGs)
            {
                ag.assignedExcludeds = new AssignedExcludedMapper().FindAssignedExcludedAGID(ag.adGroupId);
                ag.adCampaign = new AdCampaignMapper().FindAdCampaign(ag.adCampaign.campaignId);

                //vyřazení publik ze zobrazení, které jsou vyžazeny z cílení a detaily publika pro vyřazení podle kategorie
                foreach (AssignedExcluded ae in ag.assignedExcludeds.ToList())
                {
                    if (ae.action)
                    {
                        ae.audience = audienceMapper.FindAudience(ae.audience.audienceID);
                        if (ae.audience.interest != null)
                        {
                            ae.audience.interest = interestMapper.FindInterest(ae.audience.interest.interestID);
                            ae.audience.interest.categories = categoryMapper.FindCategories(ae.audience.interest.interestID);
                        }
                    }
                    else
                    {
                        ag.assignedExcludeds.Remove(ae);
                        continue;
                    }

                    if (ae.audience.category != null)
                    {
                        //tenhle if je pro kategorii
                        if (ae.audience.category.categoryID != category.categoryID)
                        {
                            //nahraju návštěvníky z patřičného publika
                            ae.audience.visitors = loadVisitors(ae.audience.audienceID);
                            continue;
                        }
                        //když bude kategorie stejná, jde se dále a nahrají se návštěvníci do publika
                        else
                        {
                            ae.audience.visitors = loadVisitors(ae.audience.audienceID);
                            continue;
                        }
                    }
                    //jestliže je přiřazený interest u publika
                    else if (ae.audience.interest != null)
                    {
                        help = false;
                        //když se najde prnví kategorie, která z interestu souhlasí s kategorií stránky, jde se dále
                        foreach (Category c in ae.audience.interest.categories)
                        {
                            if (c.categoryID == category.categoryID)
                            {
                                help = true;
                                break;
                            }
                        }
                        if (help)
                        {
                            ae.audience.visitors = loadVisitors(ae.audience.audienceID);
                        }
                        else
                        {
                            ag.assignedExcludeds.Remove(ae);
                        }
                    }
                    else
                    {
                        ag.assignedExcludeds.Remove(ae);
                    }
                }
            }
            //konec vyřazování publik
            //konec cílení podle obsahu stránky

            //tady mám nahrané všechny sestavy, které jsou relevantní k zobrazení


            //cílení podle zájmů
            //je potřeba zjistit, jestli je návštěvník v nějakém publiku

            //zjistit, jestli zrovna ten uživatel je v nějakém seznamu ???

            //zkontrolovat maximální počet zobrazení reklamy 
            //jestli nebyla už zobrazena 2x za sebou
            //Seřadit reklamy podle cenové nabídky --
            //přiřadit náhodné číslo, z počtu reklam k ceně nabídky a seřadit je potom a vybrat tu nejrelevantnější --
            //aby se zobrazily všechny reklamy a ne pořád ty stejné dokola nebo to prostě hodit random 

            List<Ad> ads = new List<Ad>();

            foreach (AdGroup ag in adGs)
            {
                ag.ads = new AdMapper().FindAds(ag.adGroupId);
                foreach (Ad ad in ag.ads)
                {
                    ad.adGroup = ag;
                    ads.Add(ad);
                }
            }

            //priorita
            Random rnd = new Random();
            List<int> randomList = new List<int>();
            int randomNumber;
            double cena;

            foreach (Ad ad in ads)
            {
                cena = ad.adGroup.adCampaign.costPer;
                if (ad.adGroup.maxCostPer != 0)
                {
                    cena = ad.adGroup.maxCostPer;
                }
                //priorita podle max ceny *2 za a náhodné číslo z celkového počtu reklam * 10
                do
                {
                    randomNumber = rnd.Next(1, ads.Count + 1);
                }
                while (randomList.Contains(randomNumber));
                randomList.Add(randomNumber);
                ad.priority = (int)(cena * 2 + (randomNumber * 10));
            }
            int max = 0;
            foreach (Ad ad in ads)
            {
                if (max < ad.priority)
                {
                    max = ad.priority;
                    adToShow = ad;
                }
            }

            //informace o reklamě
            ViewBag.adTitle = adToShow.title;
            ViewBag.Description = adToShow.description;
            ViewBag.Company = adToShow.companyName;
            ViewBag.LongTitle = adToShow.longTitle;
            ViewBag.Img = "Images/Images/log.jpg";
        }

        private List<Visitor> loadVisitors(int audienceID)
        {
            List<Visitor> visitors = new List<Visitor>();
            visitors = new VisitorMapper().FindVisitors(audienceID);
            return visitors;
        }


    }

}