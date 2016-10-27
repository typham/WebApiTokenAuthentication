using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Security;
using static WebApiTokenAuthentication.UserData;

namespace WebApiTokenAuthentication.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        public IHttpActionResult Get()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(i => i.Type == ClaimTypes.Role).Select(i => i.Value);

            return Json(new {
                Username = User.Identity.Name,
                Role = string.Join(", ", roles.ToList())
            });
        }
    }
}

