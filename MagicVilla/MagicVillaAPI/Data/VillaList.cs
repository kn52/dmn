using MagicVillaAPI.Models.DTO;

namespace MagicVillaAPI.Data
{
    public static class VillaList
    {
        public static readonly List<CNO> Villas = new()
            {
                new() { Id = 1, Name = "Pool Villa", DateTime = DateTime.Now.ToString(), Sqft = 3, Occupancy = 800 },
                new() { Id = 2, Name = "Beach Villa", DateTime = DateTime.Now.ToString(), Sqft = 3, Occupancy = 10000 }
            };
    }
}
