using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DAL;

namespace WebApi.DTO
{
    
    public class UserDTO
    {
        public UserDTO()
        {

        }
        public UserDTO(WebApi.DAL.User u)
        {
            this.password=u.password;
            this.firstName=u.firstName;
            this.lastName=u.lastName;
            this.id=u.id;
            this.username=u.username;
        }
        public WebApi.DAL.User ToUserDal(UserDTO u)
        {
            WebApi.DAL.User D = new WebApi.DAL.User();
            D.password = u.password;
            D.firstName = u.firstName;
            D.lastName = u.lastName;
            D.id = u.id;
            D.username = u.username;
            return D;
        }

        public int id { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
  

}