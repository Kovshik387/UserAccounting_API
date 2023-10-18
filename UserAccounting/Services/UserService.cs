using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;
using UserAccounting.DAL;
using UserAccounting.DAL.Entity;
using UserAccounting.Models;
using UserAccounting.DAL.Infrastructure;
using Microsoft.Extensions.Configuration;
using UserAccounting.Helpers;
using UserAccounting.Infrastructure;

namespace UserAccounting.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper; _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _userRepository.GetUserLoginDataAsync(model.Username, model.Password);

            if (user == null) return null!;

            var token = _configuration.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<AuthenticateResponse> Register(UserModel userModel)
        {
            var user = _mapper.Map<UserLoginData>(userModel);

            var correct_login = _userRepository.GetAllUserLoginDataAsync().Result.
                FirstOrDefault(login => login.Loginname == user.Loginname);
            if (correct_login != null) return null!;

            var addedUser = await _userRepository.AddUserDataAsync(new UserLoginData()
            {
                Loginname = user.Loginname, Passwordhash = user.Passwordhash,
                Role = user.Role,
            });

            var response = await Authenticate(new AuthenticateRequest
            {
                Username = user.Loginname,
                Password = user.Passwordhash
            });

            return response;
        }

        public async Task<IEnumerable<UserLoginData>> GetAll()
        {
            return await _userRepository.GetAllUserLoginDataAsync();
        }
    }
}
