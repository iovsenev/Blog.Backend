namespace Blog.Domain.Common;
public class Result
{
    public Result(
        bool isSuccess,
        Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException();
        if(!isSuccess && error == Error.None)
            throw new InvalidOperationException();

        Error = error;
        IsSuccess = isSuccess;
    }

    public Error Error { get; }
    public bool IsSuccess {  get; }
    public bool IsFailure => !IsSuccess;

    public static Result Success() => new(true, Error.None);

    public static implicit operator Result(Error error) => new(false, error);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value => IsSuccess && _value is not null
        ? _value
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator Result<TValue>(Error error) => new(default, false, error);
    public static implicit operator Result<TValue>(TValue value) => new(value, true, Error.None);
}
