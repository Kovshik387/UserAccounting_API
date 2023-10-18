using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccounting.DAL.Entity;

namespace UserAccounting.DAL.Infrastructure
{
    public interface IUserRepository
    {
        public Task<int> AddUserDataAsync(UserLoginData data);
        public Task<List<UserLoginData>> GetAllUserLoginDataAsync();
        public Task<UserLoginData?> GetUserLoginDataAsync(string name, string password);
    }
}
