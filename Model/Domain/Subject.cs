namespace student_marking_system.Model.Domain
{
    public class Subject
    {
        public int subjectId {  get; set; }
        public string subjectName { get; set; }
        public int credits{ get; set; }
        public ICollection<StudentSubject> studentSubjects { get; set; }
    }
}
