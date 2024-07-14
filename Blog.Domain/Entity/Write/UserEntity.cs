using Blog.Domain.Common;
using Blog.Domain.ValueObject;
using CSharpFunctionalExtensions;

namespace Blog.Domain.Entity.Write;
public class UserEntity : BaseEntity
{
    private UserEntity() { }    
    private UserEntity(
        string email,
        string passwordHash,
        string userName,
        DateTimeOffset registerDate)
    {
        Email = email;
        PasswordHash = passwordHash;
        RegisterDate = registerDate;
        UserName = userName;
    }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string UserName { get; private set; } 
    public DateTimeOffset RegisterDate { get; private set; }

    public string PhoneNumber { get; private set; } = null!;
    public string FirstName { get; private set; } =null!;
    public string LastName { get; private set; } = null!;
    public string SecondName { get; private set; } = null!;
    public DateTimeOffset? BirthDate { get; private set; } = null!;

    public Address Address { get; private set; } = null!;



    private List<ArticleEntity> _articles = [];
    public ICollection<ArticleEntity> Articles => _articles.ToList();


    private List<CommentEntity> _comments = [];
    public ICollection<CommentEntity> Comments => _comments.ToList();

    public static Result<UserEntity, Error> Create(
        string emailInput,
        string passwordHash,
        string? userName)
    {
        if (string.IsNullOrEmpty(passwordHash.Trim()))
            return ErrorFactory.General.InValid("This password is null or empty");

        emailInput = emailInput.Trim();

        if (string.IsNullOrEmpty(emailInput))
            return ErrorFactory.General.InValid("This email is null or empty");

        var emailResult  = VerifyProperty.VerifyEmail(emailInput);

        if (emailResult.IsFailure)
            return ErrorFactory.General.InValid("This email is not valid");

        if (string.IsNullOrEmpty(userName.Trim()))
            userName = emailResult.Value.Split('@')[0];
       userName = "@" + userName;

        return new UserEntity(emailResult.Value, passwordHash, userName, DateTimeOffset.UtcNow);
    }

    public void PostArticle(ArticleEntity article)
    {
       _articles.Add(article);
    }

    public void PostComment(CommentEntity comment)
    {
        _comments.Add(comment);
    }
}
