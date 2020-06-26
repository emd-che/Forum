using Forum.Model;

namespace Forum.Dtos
{
    public class CommentReadDto 
    {
        public int Id { get; set; }
        public string CommentBody { get; set; }

        public User User {get; set;}
        public Topic Topic {get; set;}
       
    }
}