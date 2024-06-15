using System.Text.Json;

namespace Blog.Domain.Common;
public class Error
{
    public string ErrorCode { get; }
    public string Message { get; }

    public Error(string code, string message)
    {
        ErrorCode = code;
        Message = message;
    }

    public string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }

    public Error? Deserialize(string serialized)
    {
        return JsonSerializer.Deserialize<Error>(serialized);
    }
}
