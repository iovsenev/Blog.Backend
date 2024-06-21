namespace Blog.Application.Helpers;
public class ResponseFormat
{
    public object? Result { get; }
    public object? Errors { get; }
    public DateTime TimeGenerated { get; }

    private ResponseFormat(object? result,
            object? errors)
    {
        Result = result;
        Errors = errors;
        TimeGenerated = DateTime.Now;
    }

    public static ResponseFormat Ok(object? result)
    {
        return new(result, null);
    }

    public static ResponseFormat Error(object? errors)
    {
        return new(null, errors);
    }
}
