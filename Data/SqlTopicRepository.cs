using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Model;
using Microsoft.AspNetCore.Mvc;
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
            if (topic.User != null && topic.User.Id != 0)
            {
               _context.Attach(topic.User);
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

        public IEnumerable<Topic> GetAllTopics(string search, bool related)
        {
            IQueryable<Topic> query = _context.Topics;

            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(t => t.Title.ToLower().Contains(searchLower) 
                || t.Body.ToLower().Contains(searchLower));
            }

            if (related)
            {
                query = query.Include(t => t.User)
                    .Include(t => t.Comments);
                List<Topic> topics = query.ToList();
                topics.ForEach(t => {
                    if (t.User.Topics != null)
                    {
                        t.User.Topics = null;
                    }
                    if (t.Comments != null)
                    {
                        t.Comments.ForEach(cmt => {
                            cmt.Topic = null;
                            cmt.User = null;
                        });
                    }
                });
                return topics;
            } 
            else 
            {
                return query;
            }
            
            
            
            
            // return _context.Topics
            // .Include(Topic => Topic.Comments)
            // .ToList();

            //This feels more optimized because it return the comments count rather than all the comment model but still not sure.  
            //I think I will try to add it and test it later 
            // var comments = _context.Comments.ToDictionary(c => c.TopicId, c => c);
            // return _context.Topics.Select(t => new {t.Id, t.Title, comments[t.Id].Count};
        }

        public Topic GetTopicById(int id)
        {
            Topic result = _context.Topics
            .Include(t => t.User)
            .Include(t => t.Comments)
            .ThenInclude(c => c.User)
            .First(t => t.Id == id);


            //breaking Json circular references
            //TODO: make it cleaner
            if (result != null)
            {
                if (result.User != null)
                {
                    result.User.Topics = null;
                }
                if (result.Comments != null)
                {
                    foreach (Comment cmt in result.Comments)
                    {
                        cmt.Topic = null;
                        
                        if (cmt.User != null)
                        {
                            if(cmt.User.Comments != null)
                            {
                                cmt.User.Comments = null;
                            }
                            if (cmt.User.Topics != null)
                            {
                                cmt.User.Topics = null;
                            }
                        }
                    }
                }
            }
            return result;
            
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTopic(Topic topic) {}
        

    }
}