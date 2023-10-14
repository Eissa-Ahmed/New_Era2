using System.ComponentModel.DataAnnotations.Schema;

namespace New_Era.Model.Entities
{
    public class StudentSubject
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        [InverseProperty("studentSubject")]
        public Student Student { get; set; }
        [InverseProperty("studentSubject")]
        public Subject subject { get; set; }
    }
}
