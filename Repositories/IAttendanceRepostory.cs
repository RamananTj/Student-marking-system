using student_marking_system.Model.Domain;

namespace student_marking_system.Repositories
{
    public interface IAttendanceRepostory
    {
        Task<Attendance> CreateAsync(Attendance attendance);
        Task<List<Attendance>> GetAllAttendance();
        Task<List<Attendance>> GetById(string id);
    }
}
