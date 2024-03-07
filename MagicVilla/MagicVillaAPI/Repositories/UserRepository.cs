using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Repositories
{
    public class UserRepository: GenericRepository<LocalUser>
    {
        public UserRepository(CommonDBContext db) : base(db)
        {
        }
        public async Task<List<LocalUser>> GetValidUser()
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
        public async Task<LocalUser> GetUserById(string username, int id)
        {
            try
            {
                var query = await GetEntityByPropety(filter: u => u.UserName == username && u.Id == id);
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
        public async Task<LocalUser> GetUserByUnAndPwd(string username, string password)
        {
            try
            {
                var query = await GetEntityByPropety(filter: u => u.UserName == username && u.Password == password);
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
        public async Task<(LocalUser, string)> Login(string username, string password)
        {
            try
            {
                var query = await GetUserByUnAndPwd(username, password);
                if (query != null)
                {
                    var user = query;
                    var token = string.Empty;
                    return (user, token);
                }
                return (null, string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (null, string.Empty);
            }
        }
        public async Task<bool> Register(LocalUser entity)
        {
            try
            {
                await CreateEntity(entity);
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
