using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using student_marking_system.Model.Domain;

namespace student_marking_system.Data
{
    public class ClgAuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public ClgAuthDbContext(DbContextOptions<ClgAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var studentRoleId = "7ae56c55-5eb0-4de8-a0d4-a3a4c24c29a3";
            var staffRoleId = "e29c35e1-0f92-42ae-92f4-f15182f29749";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = studentRoleId,
                    ConcurrencyStamp = studentRoleId,
                    Name = "Student",
                    NormalizedName = "Student".ToUpper()
                },
                new IdentityRole
                {
                    Id = staffRoleId,
                    ConcurrencyStamp = staffRoleId,
                    Name = "Staff",
                    NormalizedName = "Staff".ToUpper()
                }
            };
            //These roles inserted into the table ASPNetRoles
            builder.Entity<IdentityRole>().HasData(roles);   
        }
        
    }
}
