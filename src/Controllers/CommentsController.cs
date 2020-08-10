using System.Collections.Generic;
using AutoMapper;
using Forum.Data;
using Forum.Dtos;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController: ControllerBase
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public CommentsController(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<CommentReadDto>> GetAllComments()
        {
            var comments = _repository.GetAllComments();
            return Ok(_mapper.Map<IEnumerable<CommentReadDto>>(comments));
        }

        [HttpGet("{id}", Name="GetCommentById")]
        public ActionResult <Comment> GetCommentById(int id)
        {
            var comment = _repository.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommentReadDto>(comment));
        }

        [HttpPost]
        [Authorize(Policy = Policies.User)]
        public ActionResult <CommentReadDto> CreateComment(CommentCreateDto commentCreateDto)
        {
            var commentModel = _mapper.Map<Comment>(commentCreateDto);
            _repository.CreateComment(commentModel);
            _repository.SaveChanges();
            var commentReadDto =_mapper.Map<CommentReadDto>(commentModel);
            
            if(commentReadDto.User.Topics != null)
            {
                commentReadDto.User.Topics = null;
                commentReadDto.User.Comments = null;
            }
            if (commentReadDto.Topic.Comments != null)
            {
                commentReadDto.Topic.Comments = null;
            }
            if (commentReadDto.Topic.User != null)
            {
                commentReadDto.Topic.User = null;
            }

            return CreatedAtRoute(nameof(GetCommentById), new {Id = commentReadDto.Id}, commentReadDto);
        }

        [HttpPatch("{id}")]
        //TODO: make sure the User is the owner of the comment to allow editing it
        [Authorize(Policy = Policies.User)]
        public ActionResult UpdateComment(int id, CommentCreateDto commentUpdateDto)
        {
            var commentModelFromRepo = _repository.GetCommentById(id);
            if (commentModelFromRepo == null)
            {
                return NotFound();
            }     
            _mapper.Map(commentUpdateDto, commentModelFromRepo);
            _repository.UpdateComment(commentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        //TODO: make sure the User is the owner of the comment to allow editing it
        [Authorize(Policy = Policies.User)]
        public ActionResult PartialUpdateComment(int id, JsonPatchDocument<CommentCreateDto> patchDoc)
        {
            var commentModelFromRepo = _repository.GetCommentById(id);
            if (commentModelFromRepo == null)
            {
                return NotFound();
            }
            var commentToPatch = _mapper.Map<CommentCreateDto>(commentModelFromRepo);
            patchDoc.ApplyTo(commentToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if (!TryValidateModel(commentToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _repository.UpdateComment(commentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //TODO: make sure the User is the owner of the comment to allow editing it
        [Authorize(Policy = Policies.User)]
        public ActionResult DeleteComment(int id)
        {
            var commentModelFromRepo = _repository.GetCommentById(id);
            if (commentModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteComment(commentModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}