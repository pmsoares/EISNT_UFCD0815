using EISNT_UFCD0815.DataAccess.Data;
using EISNT_UFCD0815.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EISNT_UFCD0815.DataAccess.DBinitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            AppDbContext appDbContext,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Any())
                    _context.Database.Migrate();
            }
            catch { }

            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new AppUser
                {
                    UserName = "email",
                    Email = "email",
                    PhoneNumber = "phone",
                    EmailConfirmed = true,
                    Name = "name"
                }, "pass").GetAwaiter().GetResult();

                AppUser? user = _context.Users.FirstOrDefault(u => u.Email == "email");
                _userManager.AddToRoleAsync(user!, SD.Role_Admin).GetAwaiter().GetResult();
            }

            return;
        }
    }
}
