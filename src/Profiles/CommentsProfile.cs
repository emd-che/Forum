using AutoMapper;
using Forum.Dtos;
using Forum.Model;

namespace Forum.Profiles
{
    class CommentsProfile: Profile 
    {
        public CommentsProfile()
        {
            CreateMap<Comment, CommentReadDto>();
            CreateMap<Comment, CommentCreateDto>();
            CreateMap<CommentCreateDto, Comment>()
             .ForMember(d => d.User, opt => opt.MapFrom(
                src => new User {Id = src.UserId}
            ))
             .ForMember(d => d.Topic, opt => opt.MapFrom(
                src => new Topic {Id = src.TopicId}
            ))
            ;
        }
    }
}