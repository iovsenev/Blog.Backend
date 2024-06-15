namespace Blog.Domain.Common;
public static class ErrorFactory
{
    public static class General
    {
        public static Error NotFound(string? message = null)
        {
            message = message == null
                ? "Entity not found."
                : message;
            return new Error("not.found", message);
        }

        public static Error InValid(string? message = null)
        {
            message = message == null
                ? "Input data is not valid."
                : message;
            return new Error("invalid", $"{message}");
        }

        public static Error AlreadyExists(string? message = null)
        {
            message = message == null
                ? "Object already exist."
                : $": {message}";
            return new Error("already.exist", $"{message}");
        }

        public static Error AddingFalling(string? message = null)
        {
            message = message == null
                ? "The entity was not added."
                : $": {message}";
            return new Error("adding.falling", $"{message}");
        }

        public static Error SaveFalling(string? message = null)
        {
            message = message == null
                ? "The entity was not saved."
                : $": {message}";
            return new Error("save.falling", $"{message}");
        }
    }
}
