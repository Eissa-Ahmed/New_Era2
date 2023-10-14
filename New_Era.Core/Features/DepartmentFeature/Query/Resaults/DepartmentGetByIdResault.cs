namespace New_Era.Core.Features.DepartmentFeature.Query.Resaults
{
    public class DepartmentGetByIdResault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public IEnumerable<InstractorTechResault> instractorTech { get; set; }
        public IEnumerable<StudentResault> studentResault { get; set; }
        public IEnumerable<SubjectResault> subjectResault { get; set; }


    }
    public class InstractorTechResault
    {
        public int Id { get; set; }
        public string NameTech { get; set; }
    }
    public class StudentResault
    {
        public int Id { get; set; }
        public string NameStudent { get; set; }
    }
    public class SubjectResault
    {
        public int Id { get; set; }
        public string NameSubject { get; set; }
    }
}
