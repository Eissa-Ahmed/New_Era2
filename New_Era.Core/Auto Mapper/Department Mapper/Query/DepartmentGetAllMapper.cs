namespace New_Era.Core.Auto_Mapper.Department_Mapper
{
    public partial class DepartmentProfile
    {
        public void ApplyDepartmentGetAllMapper()
        {
            CreateMap<Department, DepartmentGetAllResault>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LanguageLogic.IsArbic() ? src.NameAr : src.NameEn));
        }
    }
}
