namespace New_Era.Core.Features.StudentFeature.Commands.Handler
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<StudentCreateAsyncCommand, ResponseModel<string>>,
        IRequestHandler<StudentDeleteAsyncCommand, ResponseModel<string>>,
        IRequestHandler<StudentUpdateAsyncCommand, ResponseModel<string>>
    {
        private readonly IStringLocalizer<Language> _localizer;
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStringLocalizer<Language> localizer, IStudentServices studentServices, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _studentServices = studentServices;
            _mapper = mapper;
        }

        public async Task<ResponseModel<string>> Handle(StudentCreateAsyncCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var res = await _studentServices.CreateAsync(student);
            switch (res)
            {
                case ResponseSwitch.NameIsExist:
                    return UnprocessableEntity<string>(_localizer[ErrorsResponseKeys.NameIsExist]);
                case ResponseSwitch.PhoneIsExist:
                    return UnprocessableEntity<string>(_localizer[ErrorsResponseKeys.PhoneIsExist]);
                default:
                    return SuccessSaveData<string>();
            }
        }

        public async Task<ResponseModel<string>> Handle(StudentDeleteAsyncCommand request, CancellationToken cancellationToken)
        {
            var res = await _studentServices.DeleteAsync(request.Id);
            switch (res)
            {
                case ResponseSwitch.DataNotFount:
                    return UnprocessableEntity<string>(_localizer[ErrorsResponseKeys.DataNotFount]);
                case ResponseSwitch.Done:
                    return SuccessDeleteData<string>(); ;
                default:
                    return BadRequest<string>(_localizer[ErrorsResponseKeys.DataNotFount]);
            }
        }

        public async Task<ResponseModel<string>> Handle(StudentUpdateAsyncCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var res = await _studentServices.UpdateAsync(student);
            switch (res)
            {
                case ResponseSwitch.DataNotFount:
                    return UnprocessableEntity<string>(_localizer[ErrorsResponseKeys.DataNotFount]);
                case ResponseSwitch.NameIsExist:
                    return UnprocessableEntity<string>(_localizer[ErrorsResponseKeys.NameIsExist]);
                case ResponseSwitch.PhoneIsExist:
                    return UnprocessableEntity<string>(_localizer[ErrorsResponseKeys.PhoneIsExist]);
                default:
                    return SuccessUpdateData<string>();
            }
        }

    }
}
