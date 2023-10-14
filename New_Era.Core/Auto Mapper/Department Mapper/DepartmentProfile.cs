namespace New_Era.Core.Auto_Mapper.Department_Mapper
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            ApplyDepartmentGetByIdMapper();
            ApplyDepartmentGetAllMapper();
        }
    }
}
