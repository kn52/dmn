using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.DAO;
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
            return GetAllEntity(includeProperties: "villa").ToList();
        }
        public async Task<VillaNumber> GetById(string id)
        {
            return await GetEntityByPropety(filter: e => e.Id == new Guid(id), includeProperties: "villa");
        }
        public async Task Create(VillaNumber entity)
        {
            await CreateEntity(entity);
        }
        public async Task<VillaNumber> Delete(string id)
        {
            var _villa = await GetEntityByPropety(filter: e => e.Id == new Guid(id));
            if (_villa != null)
            {
                await DeleteEntity(_villa);
            }
            return _villa;
        }
        public async Task Update(string id, VillaNumber entity)
        {
            await UpdateEntity(id, entity);
        }
        public async Task<VillaNumber> GetVillaNumberId(int villaNo)
        {
            return await GetEntityByPropety(filter: e => e.VillaNo == villaNo);
        }
    }
}