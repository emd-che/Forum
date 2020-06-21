using System.Collections.Generic;
using Forum.Data;
using Forum.Model;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController: ControllerBase
    {
        private readonly ICommentRepository _repository;

        public CommentsController(ICommentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Comment>> GetAllComments()
        {
            return Ok(_repository.GetAllComments());
        }

        [HttpGet("{id}")]
        public ActionResult <Comment> GetCommentById(int id)
        {
            return Ok(_repository.GetCommentById(id));
        }
    }
}