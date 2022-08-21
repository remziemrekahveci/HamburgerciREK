using feane.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace feane.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            //if (_db.Roles.Any(r => r.Name == "Admin")) return;

            _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "s211210082@ogr.sakarya.edu.tr",
                Email = "s211210082@ogr.sakarya.edu.tr",
                Ad = "Remzi Emre",
                Soyad = "KAHVECI",
                EmailConfirmed = true,
                PhoneNumber = "5534448847"
            }, "Rek123*").GetAwaiter().GetResult();


            _userManager.AddToRoleAsync(_db.Users.FirstOrDefaultAsync(u => u.Email == "s211210082@ogr.sakarya.edu.tr").GetAwaiter().GetResult(), "Admin").GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "s2112100820@ogr.sakarya.edu.tr",
                Email = "s2112100820@ogr.sakarya.edu.tr",
                Ad = "Remzi Emree",
                Soyad = "KAHVECII",
                EmailConfirmed = true,
                PhoneNumber = "5534448844"
            }, "Reek12346*").GetAwaiter().GetResult();


            _userManager.AddToRoleAsync(_db.Users.FirstOrDefaultAsync(u => u.Email == "s2112100820@ogr.sakarya.edu.tr").GetAwaiter().GetResult(), "Admin").GetAwaiter().GetResult();

        }
    }
}
