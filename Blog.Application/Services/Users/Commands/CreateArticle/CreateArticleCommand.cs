using Blog.Application.Interfaces.Services;

namespace Blog.Application.Services.Users.Commands.CreateArticle;

/// <summary>
/// Модель для создания статьи
/// </summary>
/// <param name="AuthorId">Уникальный идентификатор пользователя</param>
/// <param name="Title">Заголовок статьи</param>
/// <param name="Description">Краткое описание статьи</param>
/// <param name="Content">Текст статьи</param>
/// <param name="Tags">Список тегов статьи</param>
public record CreateArticleCommand(
    Guid AuthorId,
    string Title,
    string Description,
    string Content,
    ICollection<string> Tags) : ICommand;