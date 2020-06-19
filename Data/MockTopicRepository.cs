using System.Collections.Generic;
using Forum.Model;

namespace Forum.Data 
{
    public class MockTopicRepository : ITopicRepository
    {

        // public IEnumerable<Topic> GetAllTopics()
        // {
        //     var topics = new List<Topic>();
        //     topics.Add(new Topic{Id= 1, Title="Test Title 1", RepliesCount=20, ViewsCount=40, Activity=10});
        //     topics.Add(new Topic{Id= 2, Title="Test Title 2", RepliesCount=25, ViewsCount=30, Activity=4});
        //     topics.Add(new Topic{Id= 3, Title="Test Title 3", RepliesCount=40, ViewsCount=80, Activity=7});
        //     return topics;
        // }
        public IEnumerable<Topic> GetAllTopics()
        {
            var topics = new List<Topic>();
            topics.Add(new Topic{Id= 1, Title="Test Title 1", Body ="test body 1", RepliesCount=20, ViewsCount=40, Activity=10});
            topics.Add(new Topic{Id= 2, Title="Test Title 2", Body ="test body 2", RepliesCount=25, ViewsCount=30, Activity=4});
            topics.Add(new Topic{Id= 3, Title="Test Title 3", Body ="test body 3", RepliesCount=40, ViewsCount=80, Activity=7});
            topics.Add(new Topic{Id= 4, Title="It Worksss!!!", Body ="test body 4", RepliesCount=100, ViewsCount=100, Activity=100});
            return topics;
        }

        public Topic GetTopicById(int Id){
            return new Topic{Id= 4, Title="It Worksss!!!", Body ="It works!", RepliesCount=100, ViewsCount=100, Activity=100};
        }
    }
}