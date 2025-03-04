using Lingo.Model.Dto;
using Lingo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Lingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly RegisterAuthDto registerAuthDto;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        //Create Function for Register User with Roles

        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterAuthDto registerAuthDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerAuthDto.UserName,
                Email = registerAuthDto.UserName
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerAuthDto.Password);

            if (identityResult.Succeeded) {

                //Adding Roles to user
                if (registerAuthDto.Roles != null && registerAuthDto.Roles.Any())
                {
                   identityResult =  await userManager.AddToRolesAsync(identityUser, registerAuthDto.Roles);
                }

                if (identityResult.Succeeded) {

                    return Ok("New User has been Registered..");
                }

            }

            return BadRequest("Something went wrong..");

        }


        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user =  await userManager.FindByEmailAsync(loginRequestDto.UserName);

            if (user != null) { 

             var userResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (userResult)
                {
                    //Create Token
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null) {

                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(response);
                    }
  
                }

            }

            return BadRequest("Credentials mismatch..");
        }

    }
        
}
