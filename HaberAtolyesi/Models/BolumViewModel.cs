using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaberAtolyesi.Models
{
    public class BolumViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Baslik { get; set; }
        [Required]
        public string Link { get; set; }
        public string Kategori { get; set; }
        public DateTime Create_Time { get; set; }

    }
}