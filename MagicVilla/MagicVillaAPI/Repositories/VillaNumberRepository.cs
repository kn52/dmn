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
            return GetAllEntity().ToList();
        }
        public async Task<VillaNumber> GetById(string id)
        {
            return await GetVillaNumberId(Convert.ToUInt16(id));
        }
        public async Task Create(VillaNumber entity)
        {
            await CreateEntity(entity);
        }
        public async Task<VillaNumber> Delete(int id)
        {
            var _villa = await GetVillaNumberId(id);
            if (_villa != null)
            {
                await DeleteEntity(_villa);
            }
            return _villa;
        }
        public async Task Update(int id, VillaNumber entity)
        {
            await UpdateEntity(entity.Id.ToString(), entity);
        }
        public async Task<VillaNumber> GetVillaNumberId(int villaNo)
        {
            return await GetEntityByPropety(e => e.VillaNo == villaNo);
        }
    }
}