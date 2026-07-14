using student_marking_system.Model.Domain;

namespace student_marking_system.Repositories
{
    public interface ISubjectRepository
    {
        Task <Subject> CreateAsync(Subject subject);
    }
}
