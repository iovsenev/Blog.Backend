using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using FluentAssertions;

namespace Blog.Test.Entities;
public class ArticleEntityTest
{
    [Theory]
    [InlineData("some title", "some description", "some Text", null)]
    [InlineData("some title", "some description", "some Text", new string[] { "tag1", "tag2" })]
    public void CreateArticle_Success(string title, string description, string text, string[]? tags)
    {
        List<TagEntity> tagEntities = new();
        if (tags is not null){
            foreach (var tag in tags)
            {
                tagEntities.Add(TagEntity.Create(tag).Value);
            }
        }


        var result = ArticleEntity.Create(
            title, 
            description, 
            text, 
            tagEntities);

        result.IsFailure.Should().BeFalse();
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().Be(Error.None);
        result.Value.Tags.Count.Should().Be(tagEntities.Count);
    }


    [Theory]
    [InlineData("","some description","some Text",null, "The title is not valid value")]
    [InlineData("some title","","some Text",null, "The description is not valid value")]
    [InlineData("some title","some description","",null, "The text is not valid value")]
    [InlineData("some title","some description","", new string[] { "tag1", "tag2" }, "The text is not valid value")]
    public void CreateArticle_Failure(string title, string description, string text, string[]? tags, string errorMessage)
    {
        List<TagEntity> tagEntities = new();
        if (tags is not null)
        {
            foreach (var tag in tags)
            {
                tagEntities.Add(TagEntity.Create(tag).Value);
            }
        }

        var result = ArticleEntity.Create(
            title,
            description,
            text,
            tagEntities);

        result.IsFailure.Should().BeTrue();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBe(Error.None);
        result.Error.Message.Should().Be(errorMessage);
    }
}
