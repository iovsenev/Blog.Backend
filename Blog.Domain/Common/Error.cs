using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blog.Domain.Common;
public class Error
{
    public static Error None = new Error(ErrorCodes.NoError, "No Error");

    private Error(ErrorCodes code, object message)
    {
        ErrorCode = code;
        Message = message;
    }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorCodes ErrorCode { get; }
    public object Message { get; }


    public static Error InternalServer(object? message = null)
    {
        message = message ?? "Server side error.";
        return new Error(ErrorCodes.InternalServer, message);
    }

    public static Error NotFound(object? message = null)
    {
        message = message ?? "Entity not found.";
        return new Error(ErrorCodes.NotFound, message);
    }

    public static Error NotValid(object? message = null)
    {
        message = message ?? "Input data is not valid.";
        return new Error(ErrorCodes.NotValid, message);
    }

    public static Error AlreadyExists(object? message = null)
    {
        message = message ?? "Object already exist.";
        return new Error(ErrorCodes.AlreadyExists, message);
    }

    public static Error AddingFalling(object? message = null)
    {
        message = message ?? "The entity was not added.";
        return new Error(ErrorCodes.AddingFailed, message);
    }

    public static Error SaveFalling(object? message = null)
    {
        message = message ?? "The entity was not saved.";
        return new Error(ErrorCodes.SaveFalling, message);
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
