using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTokenAuthentication
{
    public class UserData
    {
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public int RoleID { get; set; }
        }

        public static List<User> users = new List<User>
        {
            new User {Id = 1, Username = "user1", Password = "123456", RoleID = 1},
            new User {Id = 2, Username = "user2", Password = "123456", RoleID = 2},
            new User {Id = 3, Username = "user3", Password = "123456", RoleID = 2}
        };
    }
}