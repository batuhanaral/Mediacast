using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaberAtolyesi.Models
{
    public class HaberViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Başlık boş bırakılamaz")]
        public string Baslik { get; set; }
        public string Konu { get; set; }
        
        public string Fotograf { get; set; }
        [Required(ErrorMessage = "Ozet boş bırakılamaz")]
        public string Ozet { get; set; }
        public DateTime Update_Time { get; set; }
        public DateTime Create_Time { get; set; }
    }
}