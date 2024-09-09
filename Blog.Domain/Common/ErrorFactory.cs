namespace Blog.Domain.Common;
public static class ErrorFactory
{
    public static class General
    {
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
    }
}
