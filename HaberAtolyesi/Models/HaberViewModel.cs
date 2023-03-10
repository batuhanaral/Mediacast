using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberAtolyesi.Models
{
    public class HaberViewModel
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Konu { get; set; }
        public string Fotograf { get; set; }
        public string Ozet { get; set; }
        public DateTime Update_Time { get; set; }
        public DateTime Create_Time { get; set; }
    }
}