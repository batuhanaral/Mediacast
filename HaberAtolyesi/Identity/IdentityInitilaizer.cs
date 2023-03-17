using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HaberAtolyesi.Identity
{
    public class IdentityInitilaizer : DropCreateDatabaseIfModelChanges<IdentityContext>
    {
        protected override void Seed(IdentityContext context)
        {

            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin rol" };
                manager.Create(role);
            }

            //Roller
            if (!context.Roles.Any(i => i.Name == "superAdmin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "superAdmin", Description = "superAdmin rol" };
                manager.Create(role);
            }
            //User
            if (!context.Users.Any(i => i.Email == "batuhanaral3@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "superAdmin", Email = "batuhanaral3@gmail.com",UserName= "batuhanaral3@gmail.com" };
                manager.Create(user,"ATA998123ata");
                manager.AddToRoles(user.Id, "superAdmin");
                manager.AddToRoles(user.Id, "admin");
            }

            base.Seed(context);
        }
    }
}