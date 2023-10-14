namespace New_Era.Model.Entities
{
    public class InstractorSubject
    {
        [ForeignKey("Instructor")]
        public int InstractorId { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Instructor Instructor { get; set; }
        public Subject Subject { get; set; }
    }
}
