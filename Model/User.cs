using System.Collections.Generic;

namespace Forum.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
        public List<Comment> Comments {get; set; } = new List<Comment>();
        //Todo: Add password and stuff
    }
}