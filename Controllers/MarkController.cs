using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_marking_system.Data;
using student_marking_system.Mappings;
using student_marking_system.Model.Domain;
using student_marking_system.Model.DTO;
using student_marking_system.Repositories;

namespace student_marking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        //private readonly AutomapperProfile mapper;       
        private readonly IMapper _mapper;
        private readonly IMarkRepository markRepository;

        public MarkController(IMarkRepository markRepository, IMapper mapper)
        {
            this.markRepository = markRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allMarks = await markRepository.GetAll();
            return Ok(allMarks);
        }
        
        //[Route("GetById")]
        [HttpGet("{id}")]        
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var marks = await markRepository.GetById(id);
            if (marks == null)
                return BadRequest("Marks not found");
            return Ok(marks);
        }

        [Authorize(Roles = "Staff")]
        //[Authorize]
        [HttpPost("AddMarks")]
        public async Task<IActionResult> AddMarks([FromBody]AddMarksRequestDto addMarksRequestDto)
        {
            var addMarksDomainModel = _mapper.Map<Marks>(addMarksRequestDto);
            var total = addMarksDomainModel.internalMark + addMarksDomainModel.externalMark;
            addMarksDomainModel.total = total;
            addMarksDomainModel = await markRepository.CreateAsync(addMarksDomainModel);
            var marksDto = _mapper.Map<Marks>(addMarksDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = marksDto.MarksId }, marksDto);
        }
    }
}
