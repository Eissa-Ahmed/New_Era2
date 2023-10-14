namespace New_Era.Core.Features.StudentFeature.Commands.Validation
{
    public class StudentUpdateValidation : AbstractValidator<StudentUpdateAsyncCommand>
    {
        private readonly IStudentServices _studentServices;
        public StudentUpdateValidation(IStudentServices studentServices)
        {
            _studentServices = studentServices;
            ApplyValidation();
        }

        private void ApplyValidation()
        {
            RuleFor(i => i.NameAr)
               .NotEmpty()
               .NotNull()
               .Length(3, 15)
               .Must(name => _studentServices.IsValid(name));
            RuleFor(i => i.NameEn)
               .NotEmpty()
               .NotNull()
               .Length(3, 15)
               .Must(name => _studentServices.IsValid(name));
            RuleFor(i => i.AddressEn)
               .NotEmpty()
               .NotNull()
               .Length(5, 50);
            RuleFor(i => i.AddressAr)
               .NotEmpty()
               .NotNull()
               .Length(5, 50);
            RuleFor(i => i.Phone)
              .Length(11, 18)
              .Must(phone => _studentServices.ValidPhoneNumber(phone))
              .When(i => !string.IsNullOrEmpty(i.Phone));
        }


    }
}
