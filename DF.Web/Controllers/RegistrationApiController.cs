using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DF.Domain.Registrations;
using DF.Infrastructure.CQRS;

namespace DF.Web.Controllers
{
    [System.Web.Http.RoutePrefix("api/register")]
    public class RegistrationApiController : ApiController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public RegistrationApiController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Register(RegisterNewUserCommand command)
        {
            this._commandDispatcher.Dispatch(command);
            return this.Ok();
        }
    }
}
