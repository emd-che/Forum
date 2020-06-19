using System.Collections.Generic;
using Forum.Data;
using Forum.Model;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/topics")]
    [ApiController]
    public class TopicsController: ControllerBase
    {
        public readonly ITopicRepository _repository;

        public TopicsController(ITopicRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<Topic>> GetAllTopics()
        {
            return Ok(_repository.GetAllTopics());
        }

        [HttpGet("{id}")]
        public ActionResult <Topic> GetTopicById(int id){
            return Ok(_repository.GetTopicById(id));
        }
    }
}