using Blog.Application.Models.Requests;
using Blog.Application.Models.Responses;
using Blog.Application.Models.ViewModels;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.Services;
public interface IReadArticleService
{
    Task<Result<GetAllArticlesByPageResponse, Error>> GetAllArticlesByPageAsync(
        GetEntityModelByPageRequest request, 
        CancellationToken token);
    Task<Result<ArticleFullViewModel, Error>> GetByIdAsync(Guid id, CancellationToken token);
}