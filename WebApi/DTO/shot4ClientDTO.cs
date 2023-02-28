using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DAL;

namespace WebApi.DTO
{
    public class shot4ClientDTO
    {
        public shot4ClientDTO(){ }
        public shot4ClientDTO(shot4Client shot)
        {
            this.shotDate = shot.shotDate??new DateTime();
            this.Id_shot4Client= shot.Id_shot4Client;
            this.tz= shot.tz;
            this.codeShot= shot.codeShot??0;

        }
        public shot4Client TOshot4ClientDAL(shot4ClientDTO shot)
        {
            shot4Client s = new shot4Client();
            s.shotDate = shot.shotDate;
            s.Id_shot4Client = shot.Id_shot4Client;
            s.tz = shot.tz;
            s.codeShot = shot.codeShot ?? 0;
            return s;

        }
         public int Id_shot4Client { get; set; }
        public string tz { get; set; }
        public Nullable<int> codeShot { get; set; }
        public DateTime shotDate { get; set; }
        
    }
}