using Microsoft.EntityFrameworkCore;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MagicVillaAPI.EntityContext.DBContext
{
    public class CommonDBContext : IdentityDbContext<ApplicationUser>
    {
        public CommonDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    } 
}
