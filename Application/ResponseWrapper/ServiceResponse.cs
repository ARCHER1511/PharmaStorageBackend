using Domain.Enums;

namespace Application.ResponseWrapper
{
    public class ServiceResponse<T>
    {
        public ResponseStatus Status { get; set; }
        public string? Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public bool Success => Status == ResponseStatus.Success;
        public ServiceResponse() { }
        public ServiceResponse(ResponseStatus status, string? message = null, T? data = default)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
