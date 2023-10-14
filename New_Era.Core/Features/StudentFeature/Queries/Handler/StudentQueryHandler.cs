namespace New_Era.Core.Features.StudentFeature.Queries.Handler
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<StudentGetAllAsyncQuery, ResponseModel<IEnumerable<StudentGetResponse>>>,
        IRequestHandler<StudentGetByIdAsyncQuery, ResponseModel<StudentGetResponse>>,
        IRequestHandler<StudentGetAllPaginationQuery, ResponseModel<PaginationModel<StudentGetResponse>>>
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Language> _localizer;

        public StudentQueryHandler(IStudentServices studentServices, IMapper mapper, IStringLocalizer<Language> localizer) : base(localizer)
        {
            _studentServices = studentServices;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<ResponseModel<IEnumerable<StudentGetResponse>>> Handle(StudentGetAllAsyncQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentServices.GetAllAsync();
            var response = _mapper.Map<IEnumerable<StudentGetResponse>>(students);
            return SuccessGetData(response);
        }

        public async Task<ResponseModel<StudentGetResponse>> Handle(StudentGetByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            //Get Student
            var student = await _studentServices.GetByIdAsync(request.Id);

            //Handler Error
            if (student is null) return NotFound<StudentGetResponse>(_localizer[ErrorsResponseKeys.DataNotFount]);
            var response = _mapper.Map<StudentGetResponse>(student);
            return SuccessGetData(response);
        }

        public async Task<ResponseModel<PaginationModel<StudentGetResponse>>> Handle(StudentGetAllPaginationQuery request, CancellationToken cancellationToken)
        {
            var students = _studentServices.GetAllPaginationAsync(request.Search);
            var studentsMap = _mapper.ProjectTo<StudentGetResponse>(students);
            var res = await studentsMap.ToPaginationList(page: request.Page, pageSize: request.PageCount);
            return SuccessGetData(res);
        }
    }
}
