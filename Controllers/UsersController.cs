using System.Collections.Generic;
using Forum.Data;
using Forum.Model;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers 
{
    [Route("api/users")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        public ActionResult <IEnumerable<User>> GetAllUsers()
        {
            return Ok(_repository.GetAllUsers());
        }

        public ActionResult <User> GetUserById(int id)
        {
            return Ok(_repository.GetUserById(id));
        }

        
    }
}