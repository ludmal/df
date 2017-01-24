using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DF.Web.Controllers
{
    public class ScriptsController : Controller
    {
        // GET: Scripts
        [AllowAnonymous]
        public ActionResult Constants()
        {
            // Obviously this will be dynamically generated
            var script = new StringBuilder();
            script.Append("(function () {");
            script.Append("angular.module('app')");
            script.Append(".constant('Settings', {");
            script.AppendFormat("ApiUrl: '{0}',", ConfigurationManager.AppSettings["ApiUrl"]);
            script.Append("});");
            script.Append("})();");
            return JavaScript(script.ToString());
        }
    }
}