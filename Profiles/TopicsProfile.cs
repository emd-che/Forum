using AutoMapper;
using Forum.Dtos;
using Forum.Model;

namespace Forum.Profiles 
{
    class TopicsProfile: Profile
    {
        public TopicsProfile()
        {
            CreateMap<Topic, TopicReadDto>();
            CreateMap<Topic, TopicCreateDto>();
            CreateMap<TopicCreateDto, Topic>()
            .ForMember(d => d.User, opt => opt.MapFrom(
                src => new User {Id = src.UserId}
            ));
        }
    } 

}