using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Model
{
    public class Topic
    {
        public int Id {get; set;}
        
        [Required]
        [MaxLength(250)]
        public string Title {get; set;}

        [Required]
        [MaxLength(1500)]
        public string Body {get; set;}

        //Todo: calculate the views count in the Frontend initial idea :
        //calculating how many navigation to the topic detail if teh visitor not owner
        //in case of users views and everything in case of all views.
        public int ViewsCount {get; set;}
        
        //Todo: Make Created at and Edited at failds
        //Todo: calculate the comments Count and the last activity later


        //Todo: make it required 
        public List<Comment> Comments { get; set; }  = new List<Comment>();
    }
}