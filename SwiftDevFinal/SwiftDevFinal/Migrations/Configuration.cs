using IdentitySample.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using IdentitySample.Models;
using System;
using System.Collections.Generic;

namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentitySample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentitySample.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(roleStore);
                var role = new ApplicationRole
                {
                    Name = "Admin",
                    Description = "Full Access"
                };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "SuperUser"))
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(roleStore);
                var role = new ApplicationRole
                {
                    Name = "SuperUser",
                    Description = "SwiftDev Developers only"
                };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Designer"))
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(roleStore);
                var role = new ApplicationRole
                {
                    Name = "Designer",
                    Description = "Can uplaod System Design Models"
                };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Team Leader"))
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(roleStore);
                var role = new ApplicationRole
                {
                    Name = "Team Leader",
                    Description = "Leader of a Group. Has Total Access to Team's Project Material. (ATM: Used only for Contact - for further development)"
                };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Project Leader"))
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(roleStore);
                var role = new ApplicationRole
                {
                    Name = "Project Leader",
                    Description = "Leader of the whole Project, oversees each Team Leader. (ATM: Used only for Contact - for further Development)"
                };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Requirements Engineering"))
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(roleStore);
                var role = new ApplicationRole
                {
                    Name = "Requirements Engineering",
                    Description = "Can Upload Documents concering the requirements."
                };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(roleStore);
                var role = new ApplicationRole
                {
                    Name = "Developer",
                    Description = "Basic Rights, which can View and Download all. Cannot upload in Requirements and System Design"
                };
                manager.Create(role);
            }


 
            
            


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
