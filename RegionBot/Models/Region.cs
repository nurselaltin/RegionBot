using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegionBot.Model
{
    public class Region
    {
        public int ID { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public int? ilID { get; set; } = 0;
        public int? ilceID { get; set; } = 0;
        public int? bucakID { get; set; } = 0;
        public int? koyID { get; set; } = 0;
        public int? mahalleID { get; set; } = 0;


        public int? ServiceilID { get; set; } = 0;
        public int? ServiceilceID { get; set; } = 0;
        public int? ServicebucakID { get; set; } = 0;
        public int? ServicekoyID { get; set; } = 0;
        public int? ServicemahalleID { get; set; } = 0;


        // public int? caddeID { get; set; } = 0;



    }
}
