using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;

namespace WebApiTokenAuthentication
{
    public class MyAuthorizationServerProvider:OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = UserData.users.FirstOrDefault(i => i.Username == context.UserName && i.Password == context.Password);

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (user != null)
            {
                var userRole = RoleData.roles.FirstOrDefault(i => i.RoleID == user.RoleID);

                identity.AddClaim(new Claim(ClaimTypes.Role, userRole.RoleName));
                identity.AddClaim(new Claim("username", user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
        }
    }
}