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
            CreateMap<CommentCreateDto, Comment>();
        }
    }
}