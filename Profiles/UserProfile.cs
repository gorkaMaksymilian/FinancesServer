using AutoMapper;
using FinancesServer.DTOs.Users;
using FinancesServer.Models.Shared;

namespace FinancesServer.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}