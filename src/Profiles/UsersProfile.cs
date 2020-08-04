using AutoMapper;
using Forum.Dtos;
using Forum.Models;

namespace Forum.Profiles 
{
    class UsersProfile: Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<User, UserCreateDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}