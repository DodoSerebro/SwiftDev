using System.Data.Entity.Migrations;
using SwiftDev.Models;
namespace SwiftDev.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SwiftDev.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        
        // -- Creating Roles for Database.
        protected override void Seed(SwiftDev.Models.ApplicationDbContext context)
        {
            this.AddUserAndRoles();
        }

        bool AddUserAndRoles()
        {
            bool success = false;

            // Super USer
            var idManager = new IdentityManager();
            success = idManager.CreateRole("SuperUser");
            if (!success == true) return success;

            // Admin
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;
            
            // Designer
            success = idManager.CreateRole("Designer");
            if (!success == true) return success;
            
            // Requirements Engineer
            success = idManager.CreateRole("ReqEngineer");
            if (!success == true) return success;

            // Developer
            success = idManager.CreateRole("Developer");
            if (!success == true) return success;

            // Team Manager
            success = idManager.CreateRole("TeamManager");
            if (!success == true) return success;

            // Tester
            success = idManager.CreateRole("Tester");
            if (!success == true) return success;

            var newSuperUser = new ApplicationUser()
            {
                UserName = "DodoSuperUser",
                FirstName = "Dorienne",
                LastName = "Grech",
                Email = "dorienne.grech.5@hotmail.com",
                CurrentProject = 0,
                UserStillEmployed = true,

            };
            return success;
        }
    }
}