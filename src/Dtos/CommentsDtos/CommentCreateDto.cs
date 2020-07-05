namespace Forum.Dtos
{
    public class CommentCreateDto
    {
        public string CommentBody { get; set; }
        public int UserId {get; set;}
        public int TopicId{get; set;}
        
    }
}