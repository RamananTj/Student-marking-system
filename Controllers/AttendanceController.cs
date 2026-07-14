using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_marking_system.Model.Domain;
using student_marking_system.Model.DTO;
using student_marking_system.Repositories;

namespace student_marking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepostory attendanceRepostory;

        public AttendanceController(IAttendanceRepostory attendanceRepostory)
        {
            this.attendanceRepostory = attendanceRepostory;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allAttendance = await attendanceRepostory.GetAllAttendance();
            return Ok(allAttendance);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var attendance = await attendanceRepostory.GetById(id);
            if (attendance == null)
                return BadRequest("Attendance not found");
            return Ok(attendance);
        }

        [Authorize(Roles = "Staff")]
        [HttpPost("AddAttendance")]
        public async Task<IActionResult> AddAttendance([FromBody] AddAttendanceRequestDto addAttendanceRequestDto)
        {
            var attendance = new Attendance
            {
                studentId = addAttendanceRequestDto.studentId,
                date = addAttendanceRequestDto.date,
                status = addAttendanceRequestDto.status
            };

            attendance = await attendanceRepostory.CreateAsync(attendance);
            return CreatedAtAction(nameof(GetById), new { id = attendance.studentId }, attendance);
        }
    }
}
