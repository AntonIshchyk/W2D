namespace Backend.Contracts.Common;

public enum ResultStatus
{
    Success,
    NotFound,
    Unauthorized,
    Invalid
}

public class Result<T>
{
    public T? Value { get; }
    public string? Error { get; }
    public ResultStatus Status { get; }

    public bool IsSuccess => Status == ResultStatus.Success;

    private Result(T value)
    {
        Value = value;
        Status = ResultStatus.Success;
    }

    private Result(ResultStatus status, string error)
    {
        Status = status;
        Error = error;
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> NotFound(string error) => new(ResultStatus.NotFound, error);
    public static Result<T> Unauthorized(string error) => new(ResultStatus.Unauthorized, error);
    public static Result<T> Invalid(string error) => new(ResultStatus.Invalid, error);
}
