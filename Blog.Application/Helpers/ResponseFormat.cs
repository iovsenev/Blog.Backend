namespace Blog.Application.Helpers;
public class ResponseFormat
{
    public object? Result { get; }
    public Dictionary<string, string[]>? Errors { get; }
    public DateTime TimeGenerated { get; }

    private ResponseFormat(object? result,
        Dictionary<string, string[]>? errors)
    {
        Result = result;
        Errors = errors;
        TimeGenerated = DateTime.Now;
    }

    public static ResponseFormat Ok(object? result)
    {
        return new(result, null);
    }

    public static ResponseFormat Error(Dictionary<string, string[]>? errors)
    {
        return new(null, errors);
    }
}
