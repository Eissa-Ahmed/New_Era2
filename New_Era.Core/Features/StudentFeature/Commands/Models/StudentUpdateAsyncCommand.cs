namespace New_Era.Core.Features.StudentFeature.Commands.Models
{
    public class StudentUpdateAsyncCommand : IRequest<ResponseModel<string>>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string AddressAr { get; set; }
        public string AddressEn { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
