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
        List<Category> categories = new CategoryMapper().FindCategories();

        public ActionResult Index()
        {

            return View(categories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult cat1()
        {


            return View();
        }

        public ActionResult cat2()
        {


            return View(categories);
        }
        public ActionResult cat3()
        {


            return View(categories);
        }
        public ActionResult cat4()
        {


            return View(categories);
        }
        public ActionResult cat5()
        {


            return View(categories);
        }


    }

}