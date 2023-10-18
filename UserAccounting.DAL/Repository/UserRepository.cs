using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccounting.DAL.Entity;
using UserAccounting.DAL.Infrastructure;

namespace UserAccounting.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<UserModuleContext> _databaseModelFactory;
        public UserRepository(IDbContextFactory<UserModuleContext> databaseModelFactory) => _databaseModelFactory = databaseModelFactory;
        
        public async Task<int> AddUserDataAsync(UserLoginData data)
        {
            using (var factory = _databaseModelFactory.CreateDbContext())
            {
                var result = await factory.UserLoginData.AddAsync(data);
                await factory.SaveChangesAsync();
                return result.Entity.Userid;
            }
        }

        public async Task<List<UserLoginData>> GetAllUserLoginDataAsync()
        {
            using (var factory = _databaseModelFactory.CreateDbContext())
                return await factory.UserLoginData.ToListAsync();
        }

        public async Task<UserLoginData?> GetUserLoginDataAsync(string name, string password)
        {
            using (var factory = _databaseModelFactory.CreateDbContext())
                return await factory.UserLoginData.FirstOrDefaultAsync(n => n.Loginname == name && n.Passwordhash == password);
        }
    }
}
