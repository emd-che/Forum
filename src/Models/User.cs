using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Username { get; set; }

        [Required]
        [MaxLength(60)]
        public string Password {get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        //Todo: make it required 
        public List<Topic> Topics { get; set; } = new List<Topic>();
        public List<Comment> Comments {get; set; } = new List<Comment>();
        //Todo: Add password and stuff
    }
}