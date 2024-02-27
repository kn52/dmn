using MagicVillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Services.DBContext
{
    public class CommonDBContext : DbContext
    {
        public CommonDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
    } 
}
