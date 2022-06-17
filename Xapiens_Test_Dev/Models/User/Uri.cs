using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5RealWorld.Models.User
{
    public class Uri_
    {
        public string url_Login { get; set; }
        public string url_ListUser { get; set; }
        public string url_Pages { get; set; }

        public Uri_()
        {
            url_Login = "https://reqres.in/api/login";
            url_ListUser = "https://reqres.in/api/users";
            url_Pages = "https://reqres.in/api/users?page=<index>";
        }
    }
}