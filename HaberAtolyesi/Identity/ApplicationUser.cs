using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HaberAtolyesi.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [DisplayName("Uyelik Durum")]
        public bool? MembershipStatus { get; set; }

        //public List<PersonelShortInfofmation> personelShortInfofmations { get; set; }
    }
}