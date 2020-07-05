using System.Collections.Generic;
using System.Linq;
using Forum.Model;

namespace Forum.Data 
{
    public class MockTopicRepository : ITopicRepository
    {
        private readonly List<Topic> _topics;
        public MockTopicRepository()
        {
            this._topics = new List<Topic>();
             var user1 = new User {Id = 1, Username = "John112", Email = "jo2532@test.test"};
            var user2 = new User {Id = 2, Username = "Steve242", Email = "S4634@test.test"};
            var user3 = new User {Id = 3, Username = "Dan151", Email = "Dan4444453@test.test"};
            var _topics = new List<Topic>();
            this._topics.Add(new Topic {
                        Id = 1,
                        Title = "How to make this code work",
                        Body = "I want to know how to make this code work",
                        ViewsCount = 20, User = user1,
                        Comments = new List<Comment> {
                            new Comment {Id = 1, CommentBody = "do this", User = user2},
                            new Comment {Id = 2, CommentBody = "alternative way of doing this", User=user3}
                        }
                    });
            this._topics.Add( new Topic {
                        Id = 2,
                        Title = "What I have learned when I did this",
                        Body = "Look what I have learned when I did this",
                        ViewsCount = 20, User = user1,
                        Comments = new List<Comment> {
                            new Comment {Id = 3, CommentBody = "Hi! this is Awesome!", User=user2},
                            new Comment {Id = 4, CommentBody = "Thank You!", User=user1}
                        } 
                    });
            this._topics.Add(new Topic {
                        Id = 3,
                        Title = "What a great community",
                        Body = "I want to share what I like about this community",
                        ViewsCount = 20, User = user2,
                        Comments = new List<Comment> {
                            new Comment {Id = 5, CommentBody = "Yes you are right", User=user1},
                            new Comment {Id = 6, CommentBody = "you forgot to mention other things", User=user3}
                        }
                    });
        }
        public void CreateTopic(Topic topic)
        {
            _topics.Add(topic);
        }

        public void DeleteTopic(Topic topic)
        {
            var existing = _topics.First(t => t.Id == topic.Id);
            _topics.Remove(existing);
        }

        // public IEnumerable<Topic> GetAllTopics()
        // {
        //     var topics = new List<Topic>();
        //     topics.Add(new Topic{Id= 1, Title="Test Title 1", RepliesCount=20, ViewsCount=40, Activity=10});
        //     topics.Add(new Topic{Id= 2, Title="Test Title 2", RepliesCount=25, ViewsCount=30, Activity=4});
        //     topics.Add(new Topic{Id= 3, Title="Test Title 3", RepliesCount=40, ViewsCount=80, Activity=7});
        //     return topics;
        // }
    

        public IEnumerable<Topic> GetAllTopics(string search, bool related)
        {     
            return _topics;
        }

        public Topic GetTopicById(int Id){
            return _topics.Where(t => t.Id == Id)
                .FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return true;   
        }

        public void UpdateTopic(Topic topic){}
    }
}