namespace Application.ResponseWrapper
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; } = new List<string>();
        public ServiceResponse() { }
        public ServiceResponse(bool success, string? message = null, T? data = default(T), List<string>? errors = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors ?? new();
        }

        public static ServiceResponse<T> SuccessResponse(T data, string? message = null)
        {
            return new ServiceResponse<T>(true, message, data);
        }

        public static ServiceResponse<T> ErrorResponse(string? message = null, List<string>? errors = null)
        {
            return new ServiceResponse<T>(false, message, default(T), errors);
        }
    }
}
