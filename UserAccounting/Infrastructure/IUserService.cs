using UserAccounting.DAL.Entity;
using UserAccounting.Models;

namespace UserAccounting.Infrastructure
{
    public interface IUserService
    {
        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);

        public Task<AuthenticateResponse> Register(UserModel userModel);

        public Task<IEnumerable<UserLoginData>> GetAll();

    }
}
