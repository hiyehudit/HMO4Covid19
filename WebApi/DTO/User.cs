using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class User
    {
        public User()
        {

        }

        public User(object user)
        {

        }

        public string id { get; set; }
        public string username { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }

        public string Token { get; set; }

    }
}