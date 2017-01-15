using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DF.Domain;
using Humanizer;

namespace DF.Web.Controllers
{
    public static class StringExt
    {
        public static bool IsValidEmail(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(str);
        }
    }

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

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Category(string cat)
        {
            ViewBag.Category = cat.Humanize(LetterCasing.Title);
            ViewBag.Title = cat.Humanize(LetterCasing.Title);
            
            using (var db = new DealContext())
            {
                if (cat.ToLower() == "top")
                {
                    var d = db.ActiveDeals.OrderByDescending(x => x.AddedDate).Take(20).ToList();
                    return View(d);
                }

                var deals = db.ActiveDeals.Where(x => x.CatSlug.Equals(cat)).ToList();
                return View(deals);
            }
        }

        [HttpGet]
        public ActionResult Search(string q)
        {
            var query = HttpUtility.UrlDecode(q);//Request.QueryString["q"];
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Category = string.Format("Search for: {0}", query);
            ViewBag.Title = ViewBag.Category;
            using (var db = new DealContext())
            {
                var deals = db.ActiveDeals.Where(x => x.Title.Contains(query)).ToList();
                return View(deals);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            using (var db = new DealContext())
            {
                var user =
                    db.Users.FirstOrDefault(
                        x => x.Username.ToLower() == model.Username.ToLower() && x.Password == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return Redirect("/");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login");
                return RedirectToAction("Login");

            }
        }

        public ActionResult NotFound()
        {
            using (var db = new DealContext())
            {
                var d = db.ActiveDeals.OrderByDescending(x => x.AddedDate).Take(20).ToList();
                return View(d);
            }
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!model.Username.IsValidEmail())
            {
                ModelState.AddModelError(string.Empty, "Invalid email address!");
                return View();//"Register");
            }


            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError(string.Empty, "Please enter a name!");
                return View();//RedirectToAction("Register");
            }


            if (string.IsNullOrEmpty(model.Password) || model.Password.Length < 6)
            {
                ModelState.AddModelError(string.Empty, "Password must be at least 6 charachters long!");
                return View();//RedirectToAction("Register");
            }

            using (var db = new DealContext())
            {
                var user =
                    db.Users.FirstOrDefault(
                        x => x.Username.ToLower() == model.Username.ToLower());
                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "User email already registerd!");
                    return View();//RedirectToAction("Register");
                }
                
                var u = new DfUser();
                u.Username = model.Username;
                u.Password = model.Password;
                u.FirstName = model.Name;
                u.LastName = "";
                u.UserEmail = model.Username;
                u.AuthCode = "";
                u.Title = "";
                u.CityId = 0;
                u.MobileNo = "";
                u.AgeGroup = "";
                u.UserGender = "";
                u.DateCreated = DateTime.UtcNow;
                u.UserActive = true;
                db.Users.Add(u);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(model.Username, false);
                return Redirect("/");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Disclaimer()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Partners(string slug)
        {
            ViewBag.Partner = slug.Humanize(LetterCasing.Title);
            ViewBag.Title = ViewBag.Partner;
            using (var db = new DealContext())
            {
                var deals = db.PartnerDeals.Where(x => x.PartnerSlug.Equals(slug)).ToList();
                return View(deals);
            }
        }

        public ActionResult Deals(string slug)
        {
            ViewBag.Title = slug.Humanize(LetterCasing.Title);
            using (var db = new DealContext())
            {
                var deal = db.ActiveDeals.FirstOrDefault(x => x.DealSlug.Equals(slug));
                var top = db.ActiveDeals.Where(x => x.CatSlug.Equals("dining")).Take(5).ToList();
                if (deal == null)
                {
                    return RedirectToAction("NotFound");
                }

                ViewBag.DealTitle = deal.Title;
                return View(new DealModel()
                {
                    Deal = deal,
                    DealList = top
                });
            }
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}