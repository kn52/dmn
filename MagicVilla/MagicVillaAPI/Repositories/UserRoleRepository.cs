using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>
    {
        public UserRoleRepository(CommonDBContext db) : base(db)
        {
        }
        public async Task<List<UserRole>> GetAllRoles()
        {
            try
            {
                var query = await GetAllEntity();
                if (query != null)
                {
                    var _user = await query.ToListAsync();
                    return _user;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<UserRole> GetRoleById(string id)
        {
            try
            {
                var query = await GetEntityByPropety(filter: u => u.Id == new Guid(id));
                if (query != null)
                {
                    var _user = await query.FirstOrDefaultAsync();
                    return _user;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<UserRole> CreateRole(UserRole entity)
        {
            try
            {
                await CreateEntity(entity);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<UserRole> DeleteRole(string id)
        {
            var entity = await GetRoleById(id).ConfigureAwait(false);
            try
            {
                if (entity != null) {
                    await CreateEntity(entity);
                }
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> UpdateRole(string id, UserRole entity)
        {
            try
            {
                await UpdateEntity(id, entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
