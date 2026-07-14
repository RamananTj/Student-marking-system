using Microsoft.EntityFrameworkCore;
using student_marking_system.Model.Domain;

namespace student_marking_system.Data
{
    public class ClgDbContext : DbContext
    {
        public ClgDbContext(DbContextOptions<ClgDbContext> options) : base (options)
        {
            
        }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Attendance> attendances { get; set; }
        public DbSet<Marks> marks { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }

    }
}
