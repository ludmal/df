using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DF.Domain;

namespace DF.Web.Controllers
{
    public class DealModel
    {
        public ActiveDeal Deal { get; set; }
        public List<ActiveDeal> DealList { get; set; }
    }

    [RoutePrefix("api/deals")]
    public class DealsApiController : ApiController
    {
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
