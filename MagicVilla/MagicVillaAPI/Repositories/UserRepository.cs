using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MagicVillaAPI.Repositories
{
    public class UserRepository: GenericRepository<LocalUser>
    {
        public UserRepository(CommonDBContext db) : base(db)
        {
        }

        public async Task<LocalUser> IsValidUser(string username, string password)
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
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<(LocalUser, string)> Login(string username, string password)
        {
            try
            {
                var query = await IsValidUser(username, password);
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
