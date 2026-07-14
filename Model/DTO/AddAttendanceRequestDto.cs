namespace student_marking_system.Model.DTO
{
    public class AddAttendanceRequestDto
    {
        public string studentId { get; set; }
        public DateOnly date { get; set; }
        public string status { get; set; }
    }
}
