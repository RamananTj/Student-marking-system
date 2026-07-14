using AutoMapper;
using student_marking_system.Model.Domain;
using student_marking_system.Model.DTO;

namespace student_marking_system.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AddMarksRequestDto, Marks>().ReverseMap();
            CreateMap<SubjectRequestDto, Subject>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
        }
    }
}
