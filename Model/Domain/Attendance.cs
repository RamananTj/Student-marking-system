namespace student_marking_system.Model.Domain
{
    public class Attendance
    {
        public int attendanceId { get; set; }
        public string studentId { get; set; }
        public DateOnly date { get; set; }
        public string status { get; set; }
    }
}
