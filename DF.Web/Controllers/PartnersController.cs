using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DF.Web.Controllers
{
    public class PartnersController : Controller
    {
        // GET: Partners
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Deals()
        {
            return View();
        }
    }
}