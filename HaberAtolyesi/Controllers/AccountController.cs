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
        [AllowAnonymous]
        public ActionResult AdminGiris()
        {
            return View();
        }

        [Authorize(Roles = "superAdmin")]
        public ActionResult ListAdmin()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }
        [AllowAnonymous]
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
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı oluşturama hatası");
                    TempData["SuccessMessageLogin"] = "Giriş bilgileriniz yanlış";
                }


            }
            return View(model);
        }
        [Authorize(Roles = "superAdmin")]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "superAdmin")]
        public ActionResult AddAdmin(Register register)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Email=register.Email;
                user.UserName = register.Email;
               
                IdentityResult result = userManager.Create(user, register.Password);
                if (result.Succeeded)
                {
                    
                    userManager.AddToRole(user.Id, "Admin");
                }
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("UserCreateError","Kullanıcı oluşturulamadı");
            }
            return View(register);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "superAdmin")]
        public ActionResult DeleteAdmin(string id)
        {
            
            var user = userManager.FindById(id);
            if (user != null)
            {
                var result = userManager.Delete(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListAdmin", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı silinirken bir hata oluştu.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
            }
            return View();
        }

    }
}