using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HaberAtolyesi.Models
{
    public class Register
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage = "Eposta adresiniz hatalıdır.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Şifrenizde en az 8 karakterden oluşmalı ve en az bir büyük harf,bir küçük harf ve bir rakam bulunmalıdır")]
        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [DisplayName("Parola Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreleriniz uyuşmuyor")]
        public string RePassword { get; set; }
    }
}