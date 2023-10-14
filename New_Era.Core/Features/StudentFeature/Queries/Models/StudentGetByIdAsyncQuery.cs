namespace New_Era.Core.Features.StudentFeature.Queries.Models
{
    public class StudentGetByIdAsyncQuery : IRequest<ResponseModel<StudentGetResponse>>
    {
        public StudentGetByIdAsyncQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
