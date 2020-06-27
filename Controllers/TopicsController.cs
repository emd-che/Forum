using System.Collections.Generic;
using AutoMapper;
using Forum.Data;
using Forum.Dtos;
using Forum.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/topics")]
    [ApiController]
    public class TopicsController: ControllerBase
    {
        private readonly ITopicRepository _repository;
        private readonly IMapper _mapper;

        public TopicsController(ITopicRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<TopicReadDto>> GetAllTopics(string search="", bool related=false)
        {
            var topics = _repository.GetAllTopics(search, related);
            return Ok(_mapper.Map<IEnumerable<TopicReadDto>>(topics));
        }

        [HttpGet("{id}", Name="GetTopicById")]
        public ActionResult <Topic> GetTopicById(int id){
            var topic = _repository.GetTopicById(id);
            if (topic != null)
            {
                return Ok(_mapper.Map<TopicReadDto>(topic));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <TopicReadDto> CreateTopic(TopicCreateDto topicCreateDto)
        {
            var topicModel = _mapper.Map<Topic>(topicCreateDto);
            _repository.CreateTopic(topicModel);
            _repository.SaveChanges();
            var topicReadDto = _mapper.Map<TopicReadDto>(topicModel);
            return CreatedAtRoute(nameof(GetTopicById), new {Id = topicReadDto.Id}, topicReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTopic(int id, TopicCreateDto topicUpdateDto)
        {
            var topicModelFromRepo = _repository.GetTopicById(id);
            if (topicModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(topicUpdateDto, topicModelFromRepo);
            _repository.UpdateTopic(topicModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateTopic(int id, JsonPatchDocument<TopicCreateDto> patchDoc)
        {
            var topicModelFromRepo = _repository.GetTopicById(id);
            if (topicModelFromRepo == null)
            {
                return NotFound();
            }
            var topicToPatch = _mapper.Map<TopicCreateDto>(topicModelFromRepo);
            //I guess I shouldn't cast it but couldn't find why I had to this time!
            patchDoc.ApplyTo(topicToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if (!TryValidateModel(topicToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(topicToPatch, topicModelFromRepo);
            _repository.UpdateTopic(topicModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTopic(int id)
        {
            var topicModelFromRepo = _repository.GetTopicById(id);
            if (topicModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteTopic(topicModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}