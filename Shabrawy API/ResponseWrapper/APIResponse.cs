using Domain.Enums;

namespace Shabrawy_API.ResponseWrapper
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public ResponseStatus Status { get; set; }
        public string? Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public APIResponse() { }
        public APIResponse(bool success, ResponseStatus status, string? message = null, T? data = default)
        {
            Success = success;
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
