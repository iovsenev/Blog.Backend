namespace Blog.Application.Models.ViewModels;

public record ArticleFullViewModel
{
    private ArticleFullViewModel() { }
    public ArticleFullViewModel(
        Guid id,
        string title,
        string description, 
        string text, 
        DateTimeOffset createdDate, 
        ShortUserViewModel author, 
        ICollection<CommentViewModel> comments)
    {
        Id = id;
        Title = title;
        Description = description;
        Text = text;
        CreatedDate = createdDate;
        Author = author;
        Comments = comments;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Text { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public ShortUserViewModel Author { get; set; }
    public ICollection<CommentViewModel> Comments { get; set; } = [];
};