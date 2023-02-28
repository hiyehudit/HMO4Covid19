using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DAL;

namespace WebApi.DTO
{
    public class AdressDTO
    {
        public AdressDTO(T_Address a)
        {
            this.postalCode = a.postalCode;
            this.city = a.city;
            this.street = a.street;
            this.numBuild = a.numBuild;
            this.tz = a.tz;


        }
        public AdressDTO()
        {

        }
        public T_Address TOAdressDAL(AdressDTO a)
        {
            T_Address t = new T_Address();
            t.postalCode = a.postalCode;
            t.city = a.city;
            t.street = a.street;
            t.numBuild = a.numBuild;
            t.tz = a.tz;

            return t;
        }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string numBuild { get; set; }
        public string tz { get; set; }
    }
}