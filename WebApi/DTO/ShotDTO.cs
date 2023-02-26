using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DAL;

namespace WebApi.DTO
{
    public class ShotDTO
    {
        public ShotDTO()
        {

        }
        public ShotDTO(Shot item)
        {
            this.codeShot = item.codeShot;
            this.manufactorer= item.manufactorer;
        }

        public int codeShot { get; set; }
        public string manufactorer { get; set; }
    }
}