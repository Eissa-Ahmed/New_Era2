namespace New_Era.Core.Response
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<Language> localizer;
        public ResponseHandler(IStringLocalizer<Language> localizer)
        {
            this.localizer = localizer;
        }
        public ResponseModel<T> SuccessGetData<T>(T data)
        {
            return new ResponseModel<T>()
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = localizer[LanguageKey.GetData],
                Meta = null,
                Data = data,
            };
        }
        public ResponseModel<T> SuccessSaveData<T>(T? data)
        {
            return new ResponseModel<T>()
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = localizer[LanguageKey.SaveData],
                Meta = null,
                Data = data,
            };
        }
        public ResponseModel<T> SuccessSaveData<T>()
        {
            return new ResponseModel<T>()
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = localizer[LanguageKey.SaveData],
                Meta = null,
            };
        }
        public ResponseModel<T> SuccessUpdateData<T>()
        {
            return new ResponseModel<T>()
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = localizer[LanguageKey.UpdateData],
                Meta = null
            };
        }
        public ResponseModel<T> SuccessDeleteData<T>()
        {
            return new ResponseModel<T>()
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Message = localizer[LanguageKey.DeleteData],
                Meta = null,
            };
        }
        public ResponseModel<T> BadRequest<T>(string error)
        {
            return new ResponseModel<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Message = error,
                Meta = null,
            };
        }
        public ResponseModel<T> NotFound<T>(string error)
        {
            return new ResponseModel<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                IsSuccess = false,
                Message = error,
                Meta = null,
            };
        }
        public ResponseModel<T> UnAuthorize<T>()
        {
            return new ResponseModel<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Message = localizer[LanguageKey.UnAuthorize],
                Meta = null,
            };
        }
        public ResponseModel<T> UnprocessableEntity<T>(string error)
        {
            return new ResponseModel<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                IsSuccess = false,
                Message = error,
                Meta = null,
            };
        }
    }
}
