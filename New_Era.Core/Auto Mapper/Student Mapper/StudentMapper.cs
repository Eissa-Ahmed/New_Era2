namespace New_Era.Core.Auto_Mapper.Student_Mapper
{
    public partial class StudentMapper : Profile
    {
        public StudentMapper()
        {
            addStudentListMapper();
            addStudentCreateMapper();
            addStudentUpdateMapper();
        }
    }
}
