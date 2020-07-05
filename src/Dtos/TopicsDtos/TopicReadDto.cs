using System.Collections.Generic;
using Forum.Model;

namespace Forum.Dtos
{
    public class TopicReadDto
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Body {get; set;}
        public int ViewsCount {get; set;}
        public User user{get; set;}
        public List<Comment> Comments { get; set; }  = new List<Comment>();
        public int commentsCount {get; set;}
    }
}