namespace New_Era.Core.Auto_Mapper.Student_Mapper
{
    public partial class StudentMapper
    {
        public void addStudentCreateMapper()
        {
            CreateMap<StudentCreateAsyncCommand, Student>();
        }
    }
}
