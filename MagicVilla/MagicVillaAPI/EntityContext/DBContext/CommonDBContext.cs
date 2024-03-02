using Microsoft.EntityFrameworkCore;
using MagicVillaAPI.Models.DAO;

namespace MagicVillaAPI.EntityContext.DBContext
{
    public class CommonDBContext : DbContext
    {
        public CommonDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Villa>().HasData(new Villa()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Royal Villa",
            //    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
            //    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
            //    Occupancy = 4,
            //    Rate = 200,
            //    Sqft = 550,
            //    Amenity = "",
            //    CreatedDateTime = DateTime.Now.ToString(),
            //    UpdatedDateTime = DateTime.Now.ToString()
            //},
            //  new Villa
            //  {
            //      Id = Guid.NewGuid(),
            //      Name = "Premium Pool Villa",
            //      Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
            //      ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
            //      Occupancy = 4,
            //      Rate = 300,
            //      Sqft = 550,
            //      Amenity = "",
            //      CreatedDateTime = DateTime.Now.ToString(),
            //      UpdatedDateTime = DateTime.Now.ToString()
            //  },
            //  new Villa
            //  {
            //      Id = Guid.NewGuid(),
            //      Name = "Luxury Pool Villa",
            //      Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
            //      ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
            //      Occupancy = 4,
            //      Rate = 400,
            //      Sqft = 750,
            //      Amenity = "",
            //      CreatedDateTime = DateTime.Now.ToString(),
            //      UpdatedDateTime = DateTime.Now.ToString()
            //  },
            //  new Villa
            //  {
            //      Id = Guid.NewGuid(),
            //      Name = "Diamond Villa",
            //      Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
            //      ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
            //      Occupancy = 4,
            //      Rate = 550,
            //      Sqft = 900,
            //      Amenity = "",
            //      CreatedDateTime = DateTime.Now.ToString(),
            //      UpdatedDateTime = DateTime.Now.ToString()
            //  },
            //  new Villa
            //  {
            //      Id = Guid.NewGuid(),
            //      Name = "Diamond Pool Villa",
            //      Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
            //      ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
            //      Occupancy = 4,
            //      Rate = 600,
            //      Sqft = 1100,
            //      Amenity = "",
            //      CreatedDateTime = DateTime.Now.ToString(),
            //      UpdatedDateTime = DateTime.Now.ToString()
            //  });
        }
    } 
}
