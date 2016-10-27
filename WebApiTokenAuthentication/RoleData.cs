using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTokenAuthentication
{
    public class RoleData
    {
        public class Role
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
        }

        public static List<Role> roles = new List<Role>
        {
            new Role {RoleID = 1, RoleName = "Admin"},
            new Role {RoleID = 2, RoleName = "User"}
        };
    }
}