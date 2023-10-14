namespace New_Era.Core.Features.StudentFeature.Commands.Models
{
    public class StudentDeleteAsyncCommand : IRequest<ResponseModel<string>>
    {
        public StudentDeleteAsyncCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
