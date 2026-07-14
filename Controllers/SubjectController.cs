using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_marking_system.Data;
using student_marking_system.Model.Domain;
using student_marking_system.Model.DTO;
using student_marking_system.Repositories;

namespace student_marking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ClgDbContext clgDbContext;
        private readonly ISubjectRepository subjectRepository;
        private readonly IMapper _mapper;


        public SubjectController(ClgDbContext clgDbContext, ISubjectRepository subjectRepository, IMapper mapper)
        {
            this.clgDbContext = clgDbContext;
            this.subjectRepository = subjectRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allSubjects = await clgDbContext.subjects.ToListAsync<Subject>();
            return Ok(allSubjects);
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var subject = await clgDbContext.subjects.FirstOrDefaultAsync<Subject>(x=> x.subjectId == id);
            if (subject == null)
                return BadRequest("Subject notfound");
            return Ok(subject);
        }
        [HttpPost("AddSubject")]
        [Authorize(Roles = "Staff")]
        public async Task <IActionResult> AddSubject([FromBody] SubjectRequestDto subjectrequestdto)
        {
            var subjectDomainModel = _mapper.Map<Subject>(subjectrequestdto);
            subjectDomainModel = await subjectRepository.CreateAsync(subjectDomainModel);
            var SubjectDto = _mapper.Map<SubjectDto>(subjectDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = SubjectDto.subjectId }, SubjectDto);
        }
    }
}
