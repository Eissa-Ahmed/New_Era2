namespace New_Era.Core.Features.DepartmentFeature.Query.Models
{
    public class DepartmentGetByIdQuery : IRequest<ResponseModel<DepartmentGetByIdResault>>
    {
        public DepartmentGetByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
