using System.Collections.Generic;
using System.Linq;
using Forum.Model;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class SqlTopicRepository : ITopicRepository
    {
        private readonly ForumContext _context;

        public SqlTopicRepository(ForumContext context)
        {
            _context = context;
        }

        public ForumContext Context { get; }

        public IEnumerable<Topic> GetAllTopics()
        {
            return _context.Topics
            .Include(Topic => Topic.Comments)
            .ToList();

            //This feels more optimized because it return the comments count rather than all the comment model but still not sure.  
            //I think I will try to add it and test it later 
            // var comments = _context.Comments.ToDictionary(c => c.TopicId, c => c);
            // return _context.Topics.Select(t => new {t.Id, t.Title, comments[t.Id].Count};
        }

        public Topic GetTopicById(int id)
        {
            throw new System.NotImplementedException();

            //return _context.Topics.FirstOrDefault(p =>  p.Id == id);
        }
    }
}