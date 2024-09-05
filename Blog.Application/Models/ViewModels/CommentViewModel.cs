namespace Blog.Application.Models.ViewModels;

public record CommentViewModel
{
    public CommentViewModel(
        Guid id, 
        string text, 
        DateTimeOffset createdDate, 
        ShortUserViewModel author)
    {
        Id = id;
        Text = text;
        CreatedDate = createdDate;
        Author = author;
    }

    public Guid Id { get; set; }
    public string Text {get;set;}
    public DateTimeOffset CreatedDate {get;set;}
    public ShortUserViewModel Author {get;set;}
}