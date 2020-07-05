using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Dtos
{
    public class TopicCreateDto
    {
        [Required]
        public string Title {get; set;}
        
        [Required]
        public string Body {get; set;}
        
        [Required]
        public int UserId {get; set;}

    }
}