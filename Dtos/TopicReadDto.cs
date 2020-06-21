using System.Collections.Generic;
namespace Forum.Dtos
{
    public class TopicReadDto
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Body {get; set;}
        public int ViewsCount {get; set;}
    }
}