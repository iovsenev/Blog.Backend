using Blog.Domain.Common;
using System.Text.Json.Serialization;

namespace Blog.Application.Helpers;
public class ResponseFormat
{
    public object? Result { get; }
    public Error? Errors { get; }
    public DateTime TimeGenerated { get; }

    private ResponseFormat(object? result,
            Error? errors)
    {
        Result = result;
        Errors = errors;
        TimeGenerated = DateTime.Now;
    }

    public static ResponseFormat Ok(object? result)
    {
        return new(result, null);
    }

    public static ResponseFormat Error(Error? errors)
    {
        return new(null, errors);
    }
}
