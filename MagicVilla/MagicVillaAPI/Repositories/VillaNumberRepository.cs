using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Migrations;
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
            return await GetEntityById(id);
        }
        public async Task Create(VillaNumber entity)
        {
            await CreateEntity(entity);
        }
        public async Task<VillaNumber> Delete(string id)
        {
            var villa = await DeleteEntity(id);
            return villa;
        }
        public async Task Update(string id, VillaNumber entity)
        {
            await UpdateEntity(id, entity);
        }
        public async Task<VillaNumber> checkVillaNumber(VillaNumberDTO villaDto)
        {
            return _db.VillaNumbers.FirstOrDefault(x => x.VillaNo == villaDto.VillaNo);
        }
    }
}