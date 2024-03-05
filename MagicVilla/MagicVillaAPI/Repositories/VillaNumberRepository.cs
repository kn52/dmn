using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MagicVillaAPI.Repositories
{
    public class VillaNumberRepository : GenericRepository<VillaNumber>
    {
        public VillaNumberRepository(CommonDBContext db) : base(db)
        {
            //_db.VillaNumbers.Include(u => u.Villa).ToList();
        }
        public async Task<List<VillaNumber>> GetAll(string? includeProperties = "Villa")
        {
            var query = await GetAllEntity();
            if (includeProperties != null)
            {
                foreach (var incudeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(incudeProp);
                }
            }
            var _villaNumbers = await query.ToListAsync();
            return _villaNumbers;
        }
        public async Task<VillaNumber> GetById(string id, string? includeProperties = "Villa")
        {
            var entity = await GetEntityByPropety(filter: e => e.Id == new Guid(id));
            if (includeProperties != null)
            {
                foreach (var incudeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    entity.Include(incudeProp);
                }
            }
            var _entity = await entity.FirstOrDefaultAsync();
            return _entity;
        }
        public async Task Create(VillaNumber entity)
        {
            await CreateEntity(entity);
        }
        public async Task<VillaNumber> Delete(string id)
        {
            var query = await GetEntityByPropety(filter: e => e.Id == new Guid(id));
            var _villa = await query.FirstOrDefaultAsync();
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
            var query = await GetEntityByPropety(filter: e => e.VillaNo == villaNo);
            if (query != null)
            {
                var _entity = await query.FirstOrDefaultAsync();
                return _entity;
            }
            return null;
        }
    }
}