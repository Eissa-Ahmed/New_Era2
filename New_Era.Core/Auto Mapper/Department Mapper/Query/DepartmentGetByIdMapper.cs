namespace New_Era.Core.Auto_Mapper.Department_Mapper
{
    public partial class DepartmentProfile
    {
        public void ApplyDepartmentGetByIdMapper()
        {
            CreateMap<Department, DepartmentGetByIdResault>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageLogic.IsArbic() ? src.NameAr : src.NameEn))
                .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => LanguageLogic.IsArbic() ? src.InstructorManage.NameAr : src.InstructorManage.NameEn))
                .ForMember(dest => dest.studentResault, opt => opt.MapFrom(src => src.Student))
                .ForMember(dest => dest.instractorTech, opt => opt.MapFrom(src => src.InstructorTech))
                .ForMember(dest => dest.subjectResault, opt => opt.MapFrom(src => src.DepartmentSubjects));

            CreateMap<Student, StudentResault>()
                .ForMember(dest => dest.NameStudent, opt => opt.MapFrom(src => LanguageLogic.IsArbic() ? src.NameAr : src.NameEn));

            CreateMap<Instructor, InstractorTechResault>()
               .ForMember(dest => dest.NameTech, opt => opt.MapFrom(src => LanguageLogic.IsArbic() ? src.NameAr : src.NameEn));

            CreateMap<DepartmentSubject, SubjectResault>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubjectId))
               .ForMember(dest => dest.NameSubject, opt => opt.MapFrom(src => LanguageLogic.IsArbic() ? src.Subject.NameAr : src.Subject.NameEn));

        }
    }
}
