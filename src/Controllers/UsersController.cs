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
    [Route("api/users")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = Policies.User)]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }


        [HttpGet]
        [Route("TestAdmin")]
        [Authorize(Policy = Policies.Admin)]
        public ActionResult <IEnumerable<UserReadDto>> TestAdminAuth()
        {
            //var users = _repository.GetAllUsers();
            return Ok("admin stuff!");
        }

        [HttpGet("{id}", Name="GetuserById")]
        public ActionResult <User> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpPost]
        public ActionResult <UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel =  _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();
            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.Id}, userReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserCreateDto userUpdateDto)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userModelFromRepo);
            _repository.UpdateUser(userModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateUser(int id, JsonPatchDocument<UserCreateDto> patchDoc)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            var userToPatch  = _mapper.Map<UserCreateDto>(userModelFromRepo);
            patchDoc.ApplyTo(userToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _repository.UpdateUser(userModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(userModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }


        
    }
}