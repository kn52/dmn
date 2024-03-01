using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Repositories.Generic;

namespace MagicVillaAPI.Repositories
{
    public class MagicVillaRepository : GenericRepository<Villa>
    {
        public MagicVillaRepository(CommonDBContext db) : base(db)
        {
        }
        public async Task<List<Villa>> GetVillas()
        {
            return GetAllEntity().ToList();
        }
        public async Task<Villa> GetVilla(string id)
        {
            return await GetEntityByPropety(e => e.Id == new Guid(id));
        }
        public async Task<Villa> Delete(string id)
        {
            var villa = await GetEntityByPropety(e => e.Id == new Guid(id));
            await DeleteEntity(villa);
            return villa;
        }
        public async Task Create(Villa entity)
        {
           await CreateEntity(entity);
        }
        public async Task Update(string id, Villa entity)
        {
            await UpdateEntity(id, entity);
        }
        public async Task<Villa> checkVilla(VillaDTO villaDto)
        {
            return await GetEntityByPropety(x => x.Name == villaDto.Name);
        }
    }
}
