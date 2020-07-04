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
using System.Linq;

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
        public void GetTopicByIdReturnsRightTopicPassed()
        {
            var id = 2;
            var ok = _controller.GetTopicById(id).Result as OkObjectResult;
            Assert.IsType<TopicReadDto>(ok.Value);
            Assert.Equal(id, (ok.Value as TopicReadDto).Id);
        }

        [Fact]
        public void CreateInvalidTopicReturnsBadRequestPassed()
        {
            var topicWithoutTitle = new TopicCreateDto() {
                Body = "test body",
                UserId = 1
            };
            _controller.ModelState.AddModelError("Title", "Required");

            var badResponse = _controller.CreateTopic(topicWithoutTitle);

            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
        }

        [Fact]
        public void CreateValidTopicReturnsCreatedAtRoutePassed()
        {
            var validTopic = new TopicCreateDto() {
                Title = "Test Title",
                Body = "Test Body",
                UserId = 1
            };

            var createdResponse = _controller.CreateTopic(validTopic);

            Assert.IsType<CreatedAtRouteResult>(createdResponse.Result);
        }

        [Fact]
        public void CreateValidTopicReturnsCreatedTopicPassed()
        {
              var validTopic = new TopicCreateDto() {
                Title = "Test Title",
                Body = "Test Body",
                UserId = 1
            };

            var createdResponse = _controller.CreateTopic(validTopic).Result as CreatedAtRouteResult;
            var topicCreated = createdResponse.Value as TopicReadDto;

            Assert.IsType<TopicReadDto>(topicCreated);
            Assert.Equal("Test Title", topicCreated.Title);

        }

        [Fact]
        public void DeleteExisitingTopicPassed()
        {
            var id = 2;
            var ok = _controller.DeleteTopic(id);

            Assert.Equal(2, _repository.GetAllTopics("", false).Count());
        }


    }
}
