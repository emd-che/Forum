using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Forum.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase 
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _repository;
        // private List<User> appUsers = new List<User> {
        //     new User {
        //         Username = "Jack014", Email = "jack0014@test.test", Password="testpass1", UserRole = "Admin"
        //     },
        //      new User {
        //         Username = "Craig", Email = "cc55@test.test", Password="testpass1", UserRole = "User"
        //     }
        // };

        public LoginController(IConfiguration config, IUserRepository repository)
        {
            _config = config;
            _repository = repository;
        }

        User AuthenticateUser(User loginCredentials)
        {
            var registredUsers = _repository.GetAllUsers().ToList();
            User user = registredUsers.SingleOrDefault(x => 
                x.Username == loginCredentials.Username && x.Password == loginCredentials.Password
            );
            return user;
        }

        string GenerateJWTToken(User userInfo) 
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials =new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username), 
                new Claim("Email", userInfo.Email),
                new Claim("role", userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                    issuer:_config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials 
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody]User login)
        {
            IActionResult response = Unauthorized();
            User user = AuthenticateUser(login);
            if (user != null) {
                Console.WriteLine(user.Username);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.UserRole);
                System.Threading.Thread.Sleep(2000);
                var tokenString = GenerateJWTToken(user);
                response =  Ok(new {
                    token = tokenString,
                    userDetails = user,
                });

            }
            return response;
        }
    }
}