namespace New_Era.Model.Entities
{
    public class Subject
    {
        public Subject()
        {
            studentSubject = new HashSet<StudentSubject>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            InstractorSubject = new HashSet<InstractorSubject>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public DateTime Period { get; set; }
        [InverseProperty("subject")]
        public IEnumerable<StudentSubject> studentSubject { get; set; }
        [InverseProperty("Subject")]
        public IEnumerable<DepartmentSubject> DepartmentSubjects { get; set; }
        [InverseProperty("Subject")]
        public IEnumerable<InstractorSubject> InstractorSubject { get; set; }
    }
}
