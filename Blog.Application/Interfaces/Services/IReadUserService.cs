﻿using Blog.Application.Models.Requests;
using Blog.Application.Models.Responses;
using Blog.Application.Models.ViewModels;
using Blog.Domain.Common;
using Blog.Domain.Entity.Read;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.Services;
public interface IReadUserService
{
    Task<Result<GetAllUsersByPageResponse, Error>> GetAllUserByPageAsync(
        GetEntityModelByPageRequest request, 
        CancellationToken token);
    Task<Result<UserPreviewViewModel, Error>> GetUserByIdAsync(Guid id, CancellationToken token);
}