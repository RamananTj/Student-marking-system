using Microsoft.AspNetCore.Identity;

namespace student_marking_system.Model.Domain
{
    public class ApplicationUser : IdentityUser
    {
        //public string UserName { get; set; }    identity user already contain this field

        public string Department { get; set; }

        public string Name { get; set; }

        public int? Year { get; set; }

        public string? Designation { get; set; }
    }
}
