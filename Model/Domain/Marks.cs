namespace student_marking_system.Model.Domain
{
    public class Marks
    {
        public int MarksId { get; set; }
        public string studentId { get; set; }
        public int subjectId { get; set; }
        public int internalMark {  get; set; }
        public int externalMark { get; set; }
        public int total { get; set; }
    }
}
