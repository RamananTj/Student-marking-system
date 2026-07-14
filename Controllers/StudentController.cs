using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using student_marking_system.Model.Domain;

namespace student_marking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public StudentController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        //[Authorize(Roles = "Staff")]
        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await userManager.GetUsersInRoleAsync("Student");

            return Ok(students.Select(x => new
            {
                x.Id,
                x.Name,
                x.Email,
                x.Department,
                x.Year
            }));
        }
    }
}
