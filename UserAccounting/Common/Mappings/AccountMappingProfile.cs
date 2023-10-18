using AutoMapper;
using UserAccounting.DAL.Entity;
using UserAccounting.Models;

namespace UserAccounting.Common.Mappings
{
    public sealed class AccountMappingProfile : Profile
    {
        public AccountMappingProfile() 
        {
            CreateMap<UserLoginData, UserModel>().ReverseMap();
            CreateMap<UserLoginData, AuthenticateResponse>().ReverseMap();
        }
    }
}
