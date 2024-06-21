using Blog.Domain.Entity.Read;

namespace Blog.Application.Models.ViewModels;

public record UserPreviewViewModel(
    Guid Id,
    string UserName,
    DateTimeOffset RegisterDate,
    string FullName,
    ICollection<ArticleShortModelForUser> Articles,
    ICollection<CommentViewModel> Comments,
    DateTimeOffset? BirthDate);
