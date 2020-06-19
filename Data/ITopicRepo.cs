using System.Collections.Generic;
using Forum.Model;

namespace  Forum.Data
{
    public interface ITopicRepo 
    {
         IEnumerable<Topic> GetAllTopics();
         Topic GetTopicById(int id);
    }
}