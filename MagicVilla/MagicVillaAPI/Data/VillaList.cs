using MagicVillaAPI.Models.DTO;

namespace MagicVillaAPI.Data
{
    public static class VillaList
    {
        //var model = villas.Select(villa => new VillaDTO()
        //{
        //    Id = villa.Id,
        //    Name = villa.Name,
        //    Details = villa.Details,
        //    Amenity = villa.Amenity,
        //    CreatedDateTime = villa.CreatedDateTime,
        //    ImageUrl = villa.ImageUrl,
        //    Occupancy = villa.Occupancy,
        //    Rate = villa.Rate,
        //    Sqft = villa.Sqft,
        //    UpdatedDateTime = villa.UpdatedDateTime,
        //}).ToList();

        public static readonly List<CNO> Villas = new()
            {
                new() { Id = 1, Name = "Pool Villa", DateTime = DateTime.Now.ToString(), Sqft = 3, Occupancy = 800 },
                new() { Id = 2, Name = "Beach Villa", DateTime = DateTime.Now.ToString(), Sqft = 3, Occupancy = 10000 }
            };
    }
}
