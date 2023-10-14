namespace New_Era.Model.Entities
{
    public class Department
    {
        public Department()
        {
            Student = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            InstructorTech = new HashSet<Instructor>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        [ForeignKey("InstructorManage")]
        public int InstManage { get; set; }
        [InverseProperty("Department")]
        public IEnumerable<Student> Student { get; set; }
        [InverseProperty("Department")]
        public IEnumerable<DepartmentSubject> DepartmentSubjects { get; set; }
        [InverseProperty("DepartmentManage")]
        public Instructor InstructorManage { get; set; }
        [InverseProperty("DepartmentTech")]
        public IEnumerable<Instructor> InstructorTech { get; set; }
    }
}
