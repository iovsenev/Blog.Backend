﻿using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Domain.Entity.Write;
public class TagEntity : BaseEntity
{
    private TagEntity() { }
    private TagEntity(string tagName)
    {
        TagName = tagName;
    }

    public string TagName { get; private set; } = string.Empty; 

    private IReadOnlyList<ArticleEntity> _articles = [];
    public List<ArticleEntity> Articles => _articles.ToList();

    public static Result<TagEntity, Error> Create(string inputTag)
    {
        inputTag = inputTag.Trim();

        return string.IsNullOrEmpty(inputTag) 
            ? ErrorFactory.General.NotValid("Tag input must be not null or not empty")
            : new TagEntity(inputTag);
    }
}
