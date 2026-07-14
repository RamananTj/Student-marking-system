namespace student_marking_system.Model.DTO
{
    public class AddMarksRequestDto
    {
        public string studentId { get; set; }
        public int subjectId { get; set; }
        public int internalMark { get; set; }
        public int externalMark { get; set; }
    }
}
