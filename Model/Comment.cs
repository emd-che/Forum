using System.ComponentModel.DataAnnotations;

namespace Forum.Model
{
    public class Comment 
    {
        public int Id { get; set; }

        

        [Required]
        [MaxLength(1500)]
        public string CommentBody { get; set; }

        [Required]
        public User User {get; set;}

        [Required]
        public Topic Topic {get; set;}
        //Todo: Maybe add quote faild
    }
}