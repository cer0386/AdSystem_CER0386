using DataLayer;

using DomainLayer;
using DomainLayer.HelpClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        public static List<Visitor> loadVisitors(int audienceID)
        {
            List<Visitor> visitors = new List<Visitor>();
            visitors = new VisitorMapper().FindVisitors(audienceID);
            return visitors;
        }
        static void Main(string[] args)
        {
            /*
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
                    else if(ae.audience.interest != null)
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

            Ad adToShow = new Ad();

            List<Ad> ads = new List<Ad>();
            
            foreach(AdGroup ag in adGs)
            {
                ag.ads = new AdMapper().FindAds(ag.adGroupId);
                foreach(Ad ad in ag.ads)
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
                if(ad.adGroup.maxCostPer != 0)
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
                ad.priority = (int)(cena *2 + (randomNumber * 10));
            }
            int max = 0;
            foreach(Ad ad in ads)
            {
                if(max < ad.priority)
                {
                    max = ad.priority;
                    adToShow = ad;
                }
            }


            //vypis
            

            Console.WriteLine("Priorita " +adToShow.priority + " ID " + adToShow.adId + " Titulek " + adToShow.title);
            */
            List<GraphDataViews> g = new List<GraphDataViews>();
            g = new AdCampaignMapper().FindViewsG(1, new DateTime(2019, 5, 2), new DateTime(2019, 5, 19));
            List<GraphDataClicks> c = new List<GraphDataClicks>();
            c = new AdCampaignMapper().FindClicksG(1, new DateTime(2019, 5, 2), new DateTime(2019, 5, 19));
            foreach (GraphDataViews ga in g)
            {
                Console.WriteLine(ga.date + " " + ga.views);
            }
            foreach (GraphDataClicks ga in c)
            {
                Console.WriteLine(ga.date + " " + ga.clicks);
            }
            double temp = (3695.0 / 35222.0) * 100;
            double t = Math.Round(temp, 2);
            Console.WriteLine(t);
            Console.ReadLine();
        }
        
    }

  
}
