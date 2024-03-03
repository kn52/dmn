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
            var _villas = await GetAllEntity();
            return _villas;
        }
        public async Task<Villa> GetVilla(string id)
        {
            var _entity = await GetEntityByPropety(filter: e => e.Id == new Guid(id));
            return _entity;
        }
        public async Task<Villa> Delete(string id)
        {
            var villa = await GetEntityByPropety(filter: e => e.Id == new Guid(id));
            if (villa != null)
            {
                await DeleteEntity(villa);
            }
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
            var _entity = await GetEntityByPropety(filter: x => x.Name == villaDto.Name);
            return _entity;
        }
    }
}
