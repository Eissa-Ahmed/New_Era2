namespace New_Era.Core.Features.StudentFeature.Queries.Models
{
    public class StudentGetAllPaginationQuery : IRequest<ResponseModel<PaginationModel<StudentGetResponse>>>
    {
        public StudentGetAllPaginationQuery(int page = 1, int pageCount = 5, string? search = null)
        {
            Page = page;
            PageCount = pageCount;
            Search = search;
        }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public string? Search { get; set; }
    }
}
