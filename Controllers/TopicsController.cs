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
        public readonly ITopicRepo _repository;

        public TopicsController(ITopicRepo repository)
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