using student_marking_system.Data;
using student_marking_system.Model.Domain;

namespace student_marking_system.Repositories
{
    public class SqlSubjectRepository : ISubjectRepository
    {
        private readonly ClgDbContext clgDbContext;

        public SqlSubjectRepository(ClgDbContext clgDbContext) 
        {
            this.clgDbContext = clgDbContext;
        }

        public async Task<Subject> CreateAsync(Subject subject)
        {
            await clgDbContext.subjects.AddAsync(subject);
            clgDbContext.SaveChanges();
            return subject;
        }
    }
}
