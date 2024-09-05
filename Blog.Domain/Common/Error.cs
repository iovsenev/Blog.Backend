using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blog.Domain.Common;
public class Error
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorCodes ErrorCode { get; }
    public object Message { get; }

    public Error(ErrorCodes code, object message)
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
