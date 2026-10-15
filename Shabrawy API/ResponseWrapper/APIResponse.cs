namespace Shabrawy_API.ResponseWrapper
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; } = new List<string>();
        public APIResponse() { }
        public APIResponse(bool success, string? message = null, T? data = default(T), List<string>? errors = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors ?? new();
        }

        public static APIResponse<T> SuccessResponse(T data, string? message = null)
        {
            return new APIResponse<T>(true, message, data);
        }

        public static APIResponse<T> ErrorResponse(string? message = null, List<string>? errors = null)
        {
            return new APIResponse<T>(false, message, default(T), errors);
        }
    }
}
