using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Model;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class SqlTopicRepository : ITopicRepository
    {
        private readonly DataContext _context;

        public SqlTopicRepository(DataContext context)
        {
            _context = context;
        }

        

        public void CreateTopic(Topic topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }
            _context.Topics.Add(topic);
        }

        public void DeleteTopic(Topic topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }
            _context.Topics.Remove(topic);
        }

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
            return _context.Topics.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTopic(Topic topic) {}
        

    }
}