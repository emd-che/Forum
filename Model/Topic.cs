namespace Forum.Model
{
    public class Topic
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Body {get; set;}
        public int RepliesCount {get; set;}
        public int ViewsCount {get; set;}
        public int Activity {get; set;}
    }
}