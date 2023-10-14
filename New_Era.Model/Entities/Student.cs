namespace New_Era.Model.Entities
{
    public class Student
    {
        public Student()
        {
            studentSubject = new HashSet<StudentSubject>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string AddressAr { get; set; }
        public string AddressEn { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        [InverseProperty("Student")]
        public IEnumerable<StudentSubject> studentSubject { get; set; }
        [InverseProperty("Student")]
        public Department Department { get; set; }
    }
}
