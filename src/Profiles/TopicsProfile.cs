using AutoMapper;
using Forum.Dtos;
using Forum.Model;

namespace Forum.Profiles 
{
    public class TopicsProfile: Profile
    {
        public TopicsProfile()
        {
            CreateMap<Topic, TopicReadDto>()
            .ForMember(d => d.commentsCount, opt => opt.MapFrom(src => src.Comments.Count));
            CreateMap<Topic, TopicCreateDto>();
            CreateMap<TopicCreateDto, Topic>()
            .ForMember(d => d.User, opt => opt.MapFrom(
                src => new User {Id = src.UserId}
            ));
        }
    } 

}