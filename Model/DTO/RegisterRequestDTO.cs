using System.ComponentModel.DataAnnotations;

namespace student_marking_system.Model.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Name { get; set; }
        public string Department { get; set; }
        public int? Year { get; set; }   
        public string Roles { get; set; }
    }
}
