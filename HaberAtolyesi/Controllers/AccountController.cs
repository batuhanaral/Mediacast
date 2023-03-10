using HaberAtolyesi.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaberAtolyesi.Models;
using Microsoft.Owin.Security;

namespace HaberAtolyesi.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
        }
        // GET: Account
        public ActionResult AdminGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminGiris(Login model)
        {
            if (ModelState.IsValid)
            {
                //Giriş işlemleri
                var user = userManager.Find(model.Email, model.Password);


                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();

                    authManager.SignIn(authProperties, identityclaims);
                    return RedirectToAction("Index2", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı oluşturama hatası");
                    ViewBag.ErrorMessage = "Giriş Bilgileriniz yanlıştır.";
                }


            }
            return View(model);
        }
    }
}