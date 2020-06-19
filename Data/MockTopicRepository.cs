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
            topics.Add(new Topic{Id= 1, TopicTitle="Test Title 1", RepliesCount=20, ViewsCount=40, Activity=10});
            topics.Add(new Topic{Id= 2, TopicTitle="Test Title 2", RepliesCount=25, ViewsCount=30, Activity=4});
            topics.Add(new Topic{Id= 3, TopicTitle="Test Title 3", RepliesCount=40, ViewsCount=80, Activity=7});
            topics.Add(new Topic{Id= 4, TopicTitle="It Worksss!!!", RepliesCount=100, ViewsCount=100, Activity=100});
            return topics;
        }

        public Topic GetTopicById(int Id){
            return new Topic{Id= 4, TopicTitle="It Worksss!!!", RepliesCount=100, ViewsCount=100, Activity=100};
        }
    }
}