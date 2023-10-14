namespace New_Era.Core.Response
{
    public class ResponseModel<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Meta { get; set; } = null;
        public T? Data { get; set; }
    }
}
