namespace Domain.Enums
{
    public enum ResponseStatus
    {
        Success = 200,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        ValidationError = 422,
        InternalServerError = 500
    }
}
