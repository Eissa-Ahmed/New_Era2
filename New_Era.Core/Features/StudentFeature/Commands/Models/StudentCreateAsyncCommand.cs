namespace New_Era.Core.Features.StudentFeature.Commands.Models
{
    public class StudentCreateAsyncCommand : IRequest<ResponseModel<string>>
    {
        public StudentCreateAsyncCommand(string nameAr, string nameEn, string addressAr, string addressEn, string phone, int departmentId)
        {
            NameAr = nameAr;
            NameEn = nameEn;
            AddressAr = addressAr;
            AddressEn = addressEn;
            Phone = phone;
            DepartmentId = departmentId;
        }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string AddressAr { get; set; }
        public string AddressEn { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
