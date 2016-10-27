using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApiTokenAuthentication.Models
{
    public class MyAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            //AuthorizeDbContext _db = new AuthorizeDbContext();
            //var userlogged = Exts.UserLogged();
            List<string> permission = new List<string> { "Account-Get" };
            //var permission = _db.Permission.Single(i => i.RoleId == userlogged.RoleId).ListPermission.Split(';');
            string currentControllerAction = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "-" + filterContext.ActionDescriptor.ActionName;
            if (!permission.Contains(currentControllerAction))
            {
                filterContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}