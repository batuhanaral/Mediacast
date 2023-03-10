using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HaberAtolyesi.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
       
        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}