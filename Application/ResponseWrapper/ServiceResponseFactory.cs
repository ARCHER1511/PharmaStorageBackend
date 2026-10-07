using Domain.Enums;

namespace Application.ResponseWrapper;

public static class ServiceResponseFactory
{
    public static ServiceResponse<T> Success<T>(
        T data,
        string message = "Operation completed successfully"
    )
    {
        return new ServiceResponse<T>(ResponseStatus.Success, message, data);
    }

    public static ServiceResponse<T> BadRequest<T>(string message = "Bad Request")
    {
        return new ServiceResponse<T>(ResponseStatus.BadRequest, message);
    }

    public static ServiceResponse<T> Unauthorized<T>(string message = "Unauthorized")
    {
        return new ServiceResponse<T>(ResponseStatus.Unauthorized, message);
    }

    public static ServiceResponse<T> Forbidden<T>(string message = "Forbidden")
    {
        return new ServiceResponse<T>(ResponseStatus.Forbidden, message);
    }

    public static ServiceResponse<T> NotFound<T>(string message = "Resource not found")
    {
        return new ServiceResponse<T>(ResponseStatus.NotFound, message);
    }

    public static ServiceResponse<T> Conflict<T>(string message = "Conflict")
    {
        return new ServiceResponse<T>(ResponseStatus.Conflict, message);
    }

    public static ServiceResponse<T> ValidationError<T>(string message = "Validation failed")
    {
        return new ServiceResponse<T>(ResponseStatus.ValidationError, message);
    }

    public static ServiceResponse<T> InternalServerError<T>(
        string message = "An unexpected error occurred"
    )
    {
        return new ServiceResponse<T>(ResponseStatus.InternalServerError, message);
    }
}
