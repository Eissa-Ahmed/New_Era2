namespace New_Era.Core.Features.DepartmentFeature.Query.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<DepartmentGetByIdQuery, ResponseModel<DepartmentGetByIdResault>>,
        IRequestHandler<DepartmentGetAllAsyncQuery, ResponseModel<IEnumerable<DepartmentGetAllResault>>>
    {
        private readonly IStringLocalizer<Language> _localizer;
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;
        public DepartmentQueryHandler(IStringLocalizer<Language> localizer, IDepartmentServices departmentServices, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _departmentServices = departmentServices;
            _mapper = mapper;
        }
        public async Task<ResponseModel<DepartmentGetByIdResault>> Handle(DepartmentGetByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentServices.GetByIdAsync(request.Id);
            if (department is null) return NotFound<DepartmentGetByIdResault>(_localizer[ErrorsResponseKeys.DataNotFount]);

            var departmentMapper = _mapper.Map<DepartmentGetByIdResault>(department);
            return SuccessGetData(departmentMapper);
        }

        public async Task<ResponseModel<IEnumerable<DepartmentGetAllResault>>> Handle(DepartmentGetAllAsyncQuery request, CancellationToken cancellationToken)
        {
            var deartments = await _departmentServices.GetAllAsync();
            var departmentsMapper = _mapper.Map<IEnumerable<DepartmentGetAllResault>>(deartments);
            return SuccessGetData(departmentsMapper);
        }
    }
}
