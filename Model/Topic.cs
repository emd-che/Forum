namespace Forum.Model
{
    public class Topic
    {
        public int Id {get; set;}
        public string TopicTitle {get; set;}
        public int RepliesCount {get; set;}
        public int ViewsCount {get; set;}
        public int Activity {get; set;}
    }
}