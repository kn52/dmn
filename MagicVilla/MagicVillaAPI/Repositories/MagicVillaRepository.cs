 using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Repositories
{
    public class MagicVillaRepository : GenericRepository<Villa>
    {
        public MagicVillaRepository(CommonDBContext db) : base(db)
        {
        }
        public async Task<List<Villa>> GetVillas(string? includeProperties = null)
        {
            var query = await GetAllEntity();
            if (includeProperties != null)
            {
                foreach (var incudeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(incudeProp);
                }
            }
            var _villas = await query.ToListAsync();
            return _villas;
        }
        public async Task<Villa> GetVilla(string id, string? includeProperties = null)
        {
            var query = await GetEntityByPropety(filter: e => e.Id == new Guid(id));
            if (includeProperties != null)
            {
                foreach (var incudeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(incudeProp);
                }
            }
            var _entity = await query.FirstOrDefaultAsync();
            return _entity;
        }
        public async Task<Villa> Delete(string id)
        {
            var query = await GetEntityByPropety(filter: e => e.Id == new Guid(id));
            var villa = await query.FirstOrDefaultAsync();
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
            var query = await GetEntityByPropety(filter: x => x.Name == villaDto.Name);
            if(query != null)
            {
                var _entity = await query.FirstOrDefaultAsync();
                return _entity;
            }
            return null;
        }
    }
}
