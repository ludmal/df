using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.UI.WebControls;
using DF.Domain;

namespace DF.Web.Controllers
{
    public class DealModel
    {
        public ActiveDeal Deal { get; set; }
        public List<ActiveDeal> DealList { get; set; }
    }

    [RoutePrefix("api/users")]
    public class UsersApiController : ApiController
    {
        [Route("profile")]
        [HttpGet]
        public IHttpActionResult GetUserProfile()
        {
            using (var db = new DealContext())
            {
                var email = User.Identity.Name;
                var user = db.Users.FirstOrDefault(x => x.Username == email);
                if (user == null)
                {
                    throw new Exception("Invalid User");
                }
                return this.Ok(new RegisterModel()
                {
                    Username = user.Username,
                    Title = user.Title,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Mobile = user.MobileNo,
                    UserGender = user.UserGender,
                    AgeGroup = user.AgeGroup,
                    AuthCode = user.AuthCode
                });
            }
        }

        [Route("profile")]
        [HttpPost]
        public IHttpActionResult UpateUserProfile(RegisterModel model)
        {
            using (var db = new DealContext())
            {
                var email = User.Identity.Name;

                var user = db.Users.FirstOrDefault(x => x.Username == email);

                if (user == null)
                {
                    throw new Exception("Invalid User");
                }

                user.Title = model.Title;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MobileNo = model.Mobile;
                user.AgeGroup = model.AgeGroup;
                user.UserGender = model.UserGender;
                user.AuthCode = model.AuthCode;

                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return this.Ok();
            }
        }

        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register(RegisterModel model)
        {
            if (!model.Username.IsValidEmail())
            {
                throw new Exception("Invalid email address!");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                throw new Exception("Please provide a password!");
            }

            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new Exception("Please enter a First name!");
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new Exception("Please enter a Last name!");
            }


            if (string.IsNullOrEmpty(model.Password) || model.Password.Length < 6)
            {
                throw new Exception("Password must be at least 6 charachters long!");
            }

            using (var db = new DealContext())
            {
                var user =
                    db.Users.FirstOrDefault(
                        x => x.Username.ToLower() == model.Username.ToLower());
                if (user != null)
                {
                    throw new Exception("Email already registered!");
                }

                var u = new DfUser();
                u.Username = model.Username;
                u.Password = model.Password;
                u.FirstName = model.FirstName;
                u.LastName = model.LastName;
                u.UserEmail = model.Username;
                u.AuthCode = model.AuthCode;
                u.Title = model.Title;
                u.CityId = 0;
                u.MobileNo = model.Mobile;
                u.AgeGroup = model.AgeGroup;
                u.UserGender = model.UserGender;
                u.DateCreated = DateTime.UtcNow;
                u.UserActive = true;
                db.Users.Add(u);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(model.Username, false);

                HttpContext.Current.Session["USERNAME"] = $"{model.FirstName} {model.LastName}";
                return this.Ok();
            }
        }
    }

    public class FavDealView
    {
        public int DealId { get; set; }
    }

    [RoutePrefix("api/deals")]
    public class DealsApiController : ApiController
    {
        [Route("fav")]
        [HttpPost]
        public IHttpActionResult FavDeal(FavDealView deal)
        {
            using (var db = new DealContext())
            {
                db.FavDeals.Add(new FavDeal()
                {
                    DealId = deal.DealId,
                    Email = User.Identity.Name
                });

                db.SaveChanges();

                return this.Ok();
            }
        }

        [Route("fav")]
        [HttpGet]
        public IHttpActionResult FavDeal()
        {
            using (var db = new DealContext())
            {
                var list = db.FavDealList.Where(x => x.Email == User.Identity.Name).ToList();
                return this.Ok(list);
            }
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetDeals()
        {
            return this.Ok("All the deals");
        }

        [Route("category/{cat}")]
        [HttpGet]
        public IHttpActionResult GetDealsByCategory(string cat)
        {
            using (var db = new DealContext())
            {
                if (cat.ToLower() == "top")
                {
                    var d = db.ActiveDeals.OrderByDescending(x => x.AddedDate).Take(20).ToList();
                    return this.Ok(d);
                }

                var deals = db.ActiveDeals.Where(x => x.CatSlug.Equals(cat)).ToList();
                return this.Ok(deals);
            }
        }

        [Route("partners/{partner}")]
        [HttpGet]
        public IHttpActionResult GetDealsByPartner(string partner)
        {
            using (var db = new DealContext())
            {
                var deals = db.PartnerDeals.Where(x => x.PartnerSlug.Equals(partner)).ToList();
                return this.Ok(deals);
            }
        }

        [Route("{slug}")]
        [HttpGet]
        public IHttpActionResult GetDealsBySlug(string slug)
        {
            using (var db = new DealContext())
            {
                var deal = db.ActiveDeals.FirstOrDefault(x => x.DealSlug.Equals(slug));
                var top = db.ActiveDeals.Where(x => x.CatSlug.Equals("dining")).Take(5).ToList();

                return this.Ok(new DealModel()
                {
                    Deal = deal,
                    DealList = top
                });
            }
        }

    }
}
