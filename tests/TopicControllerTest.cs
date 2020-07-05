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
            var okResult = _controller.GetAllTopics();

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void TestGetAllTopicsReturnsAlltopics()
        {
            var okResult = _controller.GetAllTopics().Result as OkObjectResult;

            var topics = Assert.IsType<List<TopicReadDto>>(okResult.Value);
            Assert.Equal(3, topics.Count); 
        }

        [Fact]
        public void GetTopicByIdNotFoundPassed()
        {
            var id = 800;
            var notFoundResult = _controller.GetTopicById(id);
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetTopicByIdReturnsOkPassed()
        {
            var id = 2;
            var okResult = _controller.GetTopicById(id);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetTopicByIdReturnsRightTopicPassed()
        {
            var id = 2;
            var okResult = _controller.GetTopicById(id).Result as OkObjectResult;
            Assert.IsType<TopicReadDto>(okResult.Value);
            Assert.Equal(id, (okResult.Value as TopicReadDto).Id);
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
            var okResult = _controller.DeleteTopic(id);

            Assert.Equal(2, _repository.GetAllTopics("", false).Count());
        }

        [Fact]
        public void UpdateExisitingTopicReturnsNoContentPassed()
        {
            var id = 2;
            var topicUpdate = new TopicUpdateDto() {
                Title = "Test Title",
                Body = "Test Body"
            };
            var noContentResult = _controller.UpdateTopic(id, topicUpdate);
            Assert.IsType<NoContentResult>(noContentResult);
        }


        [Fact]
        public void UpdateExisitingTopicChangesTopicPassed()
        {
            var id = 1;
            var topicUpdate = new TopicUpdateDto(){
                Title = "Test Title",
                Body = "Test Body"
            };
            var noContentResult = _controller.UpdateTopic(id, topicUpdate);
            Assert.Equal(true, _repository.GetTopicById(id).Title == topicUpdate.Title);
            Assert.Equal(true, _repository.GetTopicById(id).Body == topicUpdate.Body);
        }

        [Fact]
        public void UpdateExisitingTopicReturnsNotFoundPassed()
        {
            var id = 800; 
            var topicUpdate = new TopicUpdateDto(){
                Title = "Test Title",
                Body = "Test Body"
            };

            var notFoundResult = _controller.UpdateTopic(id, topicUpdate);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }


    }
}
