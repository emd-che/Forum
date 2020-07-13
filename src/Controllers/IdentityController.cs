using System.Threading.Tasks;
using Forum.Auth;
using Forum.Dtos;
using Forum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [ApiController]
    public class IdentityController: ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("api/register")]
        public async Task<IActionResult> Register([FromBody]UserCreateDto userCreateDto)
        {
            var authResponse = await _identityService.RegisterAsync(userCreateDto.Username, userCreateDto.Email, userCreateDto.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthenticationFailedResponse{
                    Errors = authResponse.Errors
                });
            }

            return Ok( new AuthenticationSuccessResponse {
                Token = authResponse.Token
            });
        }

    }
}