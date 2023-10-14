namespace New_Era.Model.Entities
{
    public class DepartmentSubject
    {
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
        [InverseProperty("DepartmentSubjects")]
        public Department Department { get; set; }
        [InverseProperty("DepartmentSubjects")]
        public Subject Subject { get; set; }
    }
}
