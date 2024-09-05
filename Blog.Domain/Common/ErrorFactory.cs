namespace Blog.Domain.Common;
public static class ErrorFactory
{
    public static class General
    {
        public static Error InternalServer(string message)
        {
            return new Error(ErrorCodes.InternalServer, message);
        }

        public static Error NotFound(string? message = null)
        {
            message = message == null
                ? "Entity not found."
                : message;
            return new Error(ErrorCodes.NotFound, message);
        }

        public static Error InValid(object? message = null)
        {
            message = message == null
                ? "Input data is not valid."
                : message;
            return new Error(ErrorCodes.NotValid, message);
        }

        public static Error AlreadyExists(string? message = null)
        {
            message = message == null
                ? "Object already exist."
                : $": {message}";
            return new Error(ErrorCodes.AlreadyExists, $"{message}");
        }

        public static Error AddingFalling(string? message = null)
        {
            message = message == null
                ? "The entity was not added."
                : $": {message}";
            return new Error(ErrorCodes.AddingFailed, $"{message}");
        }

        public static Error SaveFalling(string? message = null)
        {
            message = message == null
                ? "The entity was not saved."
                : $": {message}";
            return new Error(ErrorCodes.SaveFalling, $"{message}");
        }
    }
}
