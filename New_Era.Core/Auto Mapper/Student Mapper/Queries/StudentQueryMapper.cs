namespace New_Era.Core.Auto_Mapper.Student_Mapper
{
    public partial class StudentMapper
    {
        public void addStudentListMapper()
        {
            CreateMap<Student, StudentGetResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => LanguageLogic.IsArbic() ? src.Department.NameAr : src.Department.NameEn))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageLogic.IsArbic() ? src.NameAr : src.NameEn))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => LanguageLogic.IsArbic() ? src.AddressAr : src.AddressEn));
        }
    }
}
