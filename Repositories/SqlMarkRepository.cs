using Microsoft.EntityFrameworkCore;
using student_marking_system.Data;
using student_marking_system.Model.Domain;

namespace student_marking_system.Repositories
{
    public class SqlMarkRepository : IMarkRepository
    {
        private readonly ClgDbContext clgDbContext;
        public SqlMarkRepository(ClgDbContext clgDbContext)
        {
            this.clgDbContext = clgDbContext;
        }
        public async Task<Marks> CreateAsync(Marks marks)
        {
            await clgDbContext.marks.AddAsync(marks);
            clgDbContext.SaveChanges();
            return marks;
        }

        public async Task<List<Marks>> GetAll()
        {
            var allMarks = await clgDbContext.marks.ToListAsync<Marks>();
            return allMarks;
        }

        public async Task<List<Marks>> GetById(string id)
        {
           return await clgDbContext.marks.Where(x => x.studentId.Equals(id)).ToListAsync();
        }
    }
}
