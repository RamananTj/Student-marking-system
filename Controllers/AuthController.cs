using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using student_marking_system.Model.Domain;
using student_marking_system.Model.DTO;
using student_marking_system.Repositories;

namespace student_marking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        //POST:   api/auth/register
        [HttpPost]          
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDto)
        {
            var identityUser = new ApplicationUser
            {
                UserName = registerRequestDto.username,
                Name = registerRequestDto.Name,
                Email = registerRequestDto.username,
                Department = registerRequestDto.Department,
                Year = registerRequestDto.Year,                
                Designation = registerRequestDto.Roles
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (identityResult.Succeeded)
            {
                //Add roles to the user
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRoleAsync(identityUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User got registered! Please login");
                    }
                }
            }
            return BadRequest("something went wrong");
        }

        //POST:   api/auth/register
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.username);
            if (user != null)
            {
                var checkPassworResult = await userManager.CheckPasswordAsync(user, loginRequestDto.password);

                if (checkPassworResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    //create Token
                    var jwtToken = tokenRepository.CreateJwtToken(user, roles.ToList());

                    var response = new LoginResponseDto
                    {
                        JwtToken = jwtToken,
                    };
                    return Ok(response);
                }
            }
            return BadRequest("username or password is wrong!");
        }
    }
}
