namespace Blog.Domain.Constants;

public static class Permission
{

    public static class User
    {
        public const string Read = "user.read";
        public const string Create = "user.create";
        public const string Update = "user.update";
    }

    public static class Account
    {
        public const string Delete = "account.delete";
        public const string Update = "account.update";
    }

    public static class Article
    {
        public const string Publish = "article.publish";
        public const string Create = "article.create";
        public const string Delete = "article.delete";
        public const string Update = "article.update";
        public const string Read = "article.read";
    }

    public static class Comment
    {
        public const string Create = "comment.create";
        public const string Delete = "comment.delete";
        public const string Update = "comment.update";
        public const string Read = "comment.read";
    }

    public static class Role
    {
        public const string Create = "role.create";
        public const string Delete = "role.delete";
        public const string Update = "role.update";
        public const string Read = "role.read";
    }
}