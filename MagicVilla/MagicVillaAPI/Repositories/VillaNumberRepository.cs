using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Repositories.Generic;

namespace MagicVillaAPI.Repositories
{
    public class VillaNumberRepository : GenericRepository<VillaNumber>
    {
        public VillaNumberRepository(CommonDBContext db) : base(db)
        {
        }
        public async Task<List<VillaNumber>> GetAll()
        {
            return GetAllEntity().ToList();
        }
        public async Task<VillaNumber> GetById(string id)
        {
            var _vid = await GetVillaNumberId(Convert.ToUInt16(id));
            return await GetEntityById(_vid);
        }
        public async Task Create(VillaNumber entity)
        {
            await CreateEntity(entity);
        }
        public async Task<VillaNumber> Delete(int id)
        {
            var _villa = _db.VillaNumbers.FirstOrDefault(e => e.VillaNo == id);
            await DeleteEntity(_villa);
            return _villa;
        }
        public async Task Update(int id, VillaNumber entity)
        {
            await UpdateEntity(entity.Id.ToString(), entity);
        }
        public async Task<VillaNumber> checkVillaNumber(VillaNumberDTO villaDto)
        {
            return _db.VillaNumbers.FirstOrDefault(x => x.VillaNo == villaDto.VillaNo);
        }
        public async Task<string> GetVillaNumberId(int id)
        {
            var _villa = _db.VillaNumbers.FirstOrDefault(x => x.VillaNo == id);
            if (_villa != null)
            {
                return _villa.Id.ToString();
            }
            return string.Empty;
        }
    }
}