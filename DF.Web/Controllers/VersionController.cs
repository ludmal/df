using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DF.Web.Controllers
{
    [RoutePrefix("api/version")]
    public class VersionController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetVersion()
        {
            return this.Ok("0.1v");
        }
    }
}
