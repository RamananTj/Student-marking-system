using student_marking_system.Model.Domain;

namespace student_marking_system.Repositories
{
    public interface IMarkRepository
    {
        Task<Marks> CreateAsync(Marks marks);
        Task<List<Marks>> GetAll();

        Task<List<Marks>> GetById(string id);
    }
}
