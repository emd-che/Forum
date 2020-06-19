using System.Collections.Generic;
using Forum.Model;

namespace Forum.Data
{
    public class SqlTopicRespository : ITopicRepository
    {
        public IEnumerable<Topic> GetAllTopics()
        {
            throw new System.NotImplementedException();
            //return _context.Topics.ToList();
        }

        public Topic GetTopicById(int id)
        {
            throw new System.NotImplementedException();

            //return _context.Topics.FirstOrDefault(p =>  p.Id == id);
        }
    }
}