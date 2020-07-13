using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Forum.Auth;
using Forum.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Forum.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthenticationResult> RegisterAsync(string username, string email, string password)
        {
            var exisitngUser = await _userManager.FindByEmailAsync(email);
            if (exisitngUser != null)
            {
                return new AuthenticationResult {
                    Errors = new []{"User with this Email is already exists"}
                };   
            }

            var newUser = new IdentityUser {
                Email = email,
                UserName = username
            };
            var createdUser = await _userManager.CreateAsync(newUser, password); 

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new [] {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id) 
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult {
                Success = true, 
                Token = tokenHandler.WriteToken(token),
            };

        }
    }
}