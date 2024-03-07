using Microsoft.EntityFrameworkCore;
using MagicVillaAPI.Models.DAO;

namespace MagicVillaAPI.EntityContext.DBContext
{
    public class CommonDBContext : DbContext
    {
        public CommonDBContext(DbContextOptions options) : base(options)
        {
        }
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
