using System.ComponentModel.DataAnnotations;

namespace student_marking_system.Model.DTO
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
