namespace New_Era.Model.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            InstractorSubjects = new HashSet<InstractorSubject>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string AddressAr { get; set; }
        public string AddressEn { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Image { get; set; }
        [ForeignKey("InstructorSupervisor")]
        public int? SupervisorId { get; set; }
        [ForeignKey("DepartmentTech")]
        public int? DepartmentId { get; set; }
        [InverseProperty("InstructorSupervisor")]
        public IEnumerable<Instructor> Instructors { get; set; }
        [InverseProperty("Instructors")]
        public Instructor InstructorSupervisor { get; set; }
        [InverseProperty("InstructorManage")]
        public Department DepartmentManage { get; set; }
        [InverseProperty("InstructorTech")]
        public Department DepartmentTech { get; set; }
        [InverseProperty("Instructor")]
        public IEnumerable<InstractorSubject> InstractorSubjects { get; set; }

    }
}
