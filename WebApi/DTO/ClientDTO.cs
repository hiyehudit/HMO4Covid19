using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class ClientDTO
    {
        public string tz { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string postalCode { get; set; }
        public DateTime birthDate { get; set; }
        public string telephone { get; set; }
        public string selphone { get; set; }
        public DateTime beIllDate { get; set; }
        public DateTime beHealthDate { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string numB { get; set; }
    }
}