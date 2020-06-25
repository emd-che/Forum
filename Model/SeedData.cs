using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Data;
using Forum.Model;
using Microsoft.EntityFrameworkCore;
namespace Forum
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
            if (context.Topics.Count() == 0)
            {
                var user1 = new User {Username = "John112", Email = "jo2532@test.test"};
                var user2 = new User {Username = "Steve242", Email = "S4634@test.test"};
                var user3 = new User {Username = "Dan151", Email = "Dan4444453@test.test"};
                
                context.Topics.AddRange(
                    new Topic {
                        Title = "How to make this code work",
                        Body = "I want to know how to make this code work",
                        ViewsCount = 20, User = user1,
                        Comments = new List<Comment> {
                            new Comment {CommentBody = "do this"},
                            new Comment {CommentBody = "alternative way of doing this"}
                        }
                    },
                    new Topic {
                        Title = "What I have learned when I did this",
                        Body = "Look what I have learned when I did this",
                        ViewsCount = 20, User = user1,
                        Comments = new List<Comment> {
                            new Comment {CommentBody = "Hi! this is Awesome!"},
                            new Comment {CommentBody = "Thank You!"}
                        } 
                    },
                    new Topic {
                        Title = "What a great comunity",
                        Body = "I want to share what I like about this comunity",
                        ViewsCount = 20, User = user2,
                        Comments = new List<Comment> {
                            new Comment {CommentBody = "Yes you are right"},
                            new Comment {CommentBody = "you forgot to mention other things"}
                        }
                    },
                    new Topic {
                        Title = "which is better X or Y",
                        Body = "I'm confused between X or Y",
                        ViewsCount = 20, User = user2,
                        Comments = new List<Comment> {
                            new Comment {CommentBody = "Oh C'mon"},
                            new Comment {CommentBody = "They are the same things"}
                        } 
                    },
                    new Topic {
                        Title = "How to optimize stuff",
                        Body = "This thing is too slow how can i speed it up",
                        ViewsCount = 20, User = user3,
                        Comments = new List<Comment> {
                            new Comment {CommentBody = "Remove sttuff"},
                            new Comment {CommentBody = "change this code to this"}
                        }
                    },
                    new Topic {
                        Title = "Help me",
                        Body = "help me do this",
                        ViewsCount = 20, User = user1,
                        Comments = new List<Comment> {
                            new Comment {CommentBody = "okey give us more details"},
                            new Comment {CommentBody = "hmmm you made me curious, what's that for?"}
                        } 
                    }
                );
                context.SaveChanges();
            }
        }

      
    }
}