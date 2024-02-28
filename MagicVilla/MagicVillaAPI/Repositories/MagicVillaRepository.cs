using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.EntityContext.DBContext.Common;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;

namespace MagicVillaAPI.Repositories
{
    public class MagicVillaRepository : CommonContextIns
    {
        public MagicVillaRepository(CommonDBContext db) : base(db)
        {
        }
        public async Task<List<Villa>> GetVillas()
        {
            return _db.Villas.ToList();
        }
        public async Task<Villa> GetVilla(string id)
        {
            return _db.Villas.FirstOrDefault(x => x.Id == new Guid(id));
        }
        public async Task Remove(Villa entity)
        {
            _db.Villas.Remove(entity);
            await save();
        }
        public async Task Create(Villa entity)
        {
            _db.Villas.Add(entity);
            await save();
        }
        public async Task Update(Villa entity)
        {
            _db.Villas.Update(entity);
            await save();
        }
        private async Task save()
        {
            _db.SaveChanges();
        }
        public async Task<Villa> checkVilla(VillaDTO villaDto)
        {
            return _db.Villas.FirstOrDefault(x => x.Name == villaDto.Name);
        }
    }
}
