namespace student_marking_system.Model.Domain
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int studentId{ get; set; }
        //public Student student { get; set; }
        public int subjectId { get; set; }
        public Subject subject { get; set; }
    }
}
