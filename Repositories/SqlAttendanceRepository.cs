using Microsoft.EntityFrameworkCore;
using student_marking_system.Data;
using student_marking_system.Model.Domain;

namespace student_marking_system.Repositories
{
    public class SqlAttendanceRepository : IAttendanceRepostory
    {
        private readonly ClgDbContext clgDbContext;

        public SqlAttendanceRepository(ClgDbContext clgDbContext)
        {
            this.clgDbContext = clgDbContext;
        }

        public async Task<Attendance> CreateAsync(Attendance attendance)
        {
            await clgDbContext.attendances.AddAsync(attendance);
            await clgDbContext.SaveChangesAsync();
            return attendance;
        }
        
        public async Task<List<Attendance>> GetAllAttendance()
        {
           var attendance = await clgDbContext.attendances.ToListAsync<Attendance>();
            return attendance;
        }

        public async Task<List<Attendance>> GetById(string id)
        {
            return await clgDbContext.attendances.Where(x => x.studentId.Equals(id)).ToListAsync();
        }
    }
}
