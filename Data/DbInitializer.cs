using Hotel.Models;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext db,
            UserManager<ApplicationUser> um,
            RoleManager<IdentityRole> rm)
        {
            // Delete the database before we initialize
            db.Database.EnsureDeleted();
            
            // Make sure the database and table exist
            db.Database.EnsureCreated();
            
            // Create roles
            var adminRole = new IdentityRole("Admin");
            rm.CreateAsync(adminRole).Wait();
            
            // Create users
            var admin = new ApplicationUser {UserName = "admin@uia.no", Email = "admin@uia.no"};
            um.CreateAsync(admin, "Password1.").Wait();
            um.AddToRoleAsync(admin, "Admin").Wait();

            var user = new ApplicationUser {UserName = "user@uia.no", Email = "user@uia.no"};
            um.CreateAsync(user, "Password1.").Wait();
            
            // Finally save changes to the database
            db.SaveChanges();
        }
        
    }
}