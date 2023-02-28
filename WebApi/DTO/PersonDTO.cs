using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DAL;

namespace WebApi.DTO
{
    public class PersonDTO
    {
        public PersonDTO() { }

        public PersonDTO(Person p)
        {
            this.tz = p.tz;
            this.firstName = p.firstName;
            this.lastName = p.lastName;
            this.postalCode = p.postalCode;
            this.birthDate = p.birthDate;
               // ??new DateTime();
            this.telephone = p.telephone;
            this.selphone = p.selphone;
            this.beIllDate = p.beIllDate;
            //?? new DateTime();
            this.beHealthDate = p.beHealthDate; 
                //?? new DateTime();
        }
        public Person ToPersonDAL(PersonDTO p)
        {
            Person person = new Person();
            person.tz = p.tz;
            person.firstName = p.firstName;
            person.lastName = p.lastName;
            person.postalCode = p.postalCode;
            person.birthDate = p.birthDate ?? null;
            person.telephone = p.telephone;
            person.selphone = p.selphone;
            person.beIllDate = p.beIllDate ?? null;
            person.beHealthDate = p.beHealthDate ?? null;
            return person;
        }
        public string tz { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string postalCode { get; set; }
        public Nullable<DateTime> birthDate { get; set; }
        public string telephone { get; set; }
        public string selphone { get; set; }
        public Nullable<DateTime> beIllDate { get; set; }
        public Nullable<DateTime> beHealthDate { get; set; }
    }
}