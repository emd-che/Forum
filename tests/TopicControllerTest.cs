using System;
using System.Collections.Generic;
using AutoMapper;
using Forum.Controllers;
using Forum.Data;
using Forum.Dtos;
using Forum.Model;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Forum.Profiles;

namespace ForumTests
{
    public class TopicControllerTest
    {
        TopicsController _controller;
        ITopicRepository _repository;

        IMapper _mapper;



        public TopicControllerTest()
        {
             var config = new MapperConfiguration(opts =>
                {
                   opts.AddProfile(new TopicsProfile());
                });

             _mapper = config.CreateMapper(); 
 
            _repository = new MockTopicRepository();
            _controller = new TopicsController(_repository, _mapper);
           
        }

        

        [Fact]
        public void TestGetAllTopicsReturnsOk()
        {
            var ok = _controller.GetAllTopics();

            Assert.IsType<OkObjectResult>(ok.Result);
        }

        [Fact]
        public void TestGetAllTopicsReturnsAlltopics()
        {
            var ok = _controller.GetAllTopics().Result as OkObjectResult;

            var topics = Assert.IsType<List<TopicReadDto>>(ok.Value);
            Assert.Equal(3, topics.Count); 
        }

        [Fact]
        public void GetTopicByIdNotFoundPassed()
        {
            var notFound = _controller.GetTopicById(8);
            Assert.IsType<NotFoundResult>(notFound.Result);
        }

        [Fact]
        public void GetTopicByIdReturnsOkPassed()
        {
            var ok = _controller.GetTopicById(2);
            Assert.IsType<OkObjectResult>(ok.Result);
        }

        [Fact]
        public void GetTopicByIdReturnRightTopicPassed()
        {
            var id = 2;
            var ok = _controller.GetTopicById(id).Result as OkObjectResult;
            Assert.IsType<TopicReadDto>(ok.Value);
            Assert.Equal(id, (ok.Value as TopicReadDto).Id);
        }

        [Fact]
        public void AddInvalidTopicReturnsBadRequestPassed()
        {
            var topicWithoutTitle = new TopicCreateDto() {
                Body = "test body",
                UserId = 1
            };
            _controller.ModelState.AddModelError("Title", "Required");

            var badResponse = _controller.CreateTopic(topicWithoutTitle);

            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        


    }
}
