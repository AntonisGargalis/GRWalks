using GRWalks.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GRWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerDto.Password);

            if (identityResult.Succeeded) 
            {
                //Add roles to the user
                if(registerDto.Roles != null && registerDto.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("Register Success");
                    }
                }
                
            }

            return BadRequest("Something went wrong. Please try again");

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Username);

            if (user != null)
            {
                var checkPasswordUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

                if (checkPasswordUser)
                {
                    return Ok();
                }
            }

            return BadRequest("Username or password is incorrect");
        }

    }
}
