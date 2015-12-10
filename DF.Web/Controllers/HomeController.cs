using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DF.Domain;

namespace DF.Web.Controllers
{
    public class DealModel
    {
        public ActiveDeal Deal { get; set; }
        public List<ActiveDeal> DealList { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(string cat)
        {
            ViewBag.Category = cat;
            using (var db = new DealContext())
            {
                var deals = db.ActiveDeals.Where(x => x.CatSlug.Equals(cat)).ToList();
                return View(deals);
            }
        }

        public ActionResult Deals(string slug)
        {
            using (var db = new DealContext())
            {
                var deal = db.ActiveDeals.FirstOrDefault(x => x.DealSlug.Equals(slug));
                var top = db.ActiveDeals.Where(x => x.CatSlug.Equals("dining")).Take(5).ToList();
                ViewBag.DealTitle = deal.Title;
                return View(new DealModel()
                {
                    Deal = deal,
                    DealList = top
                });
            }
        }
    }
}