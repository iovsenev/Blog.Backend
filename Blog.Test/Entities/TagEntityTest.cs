using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using FluentAssertions;

namespace Blog.Test.Entities;
public class TagEntityTest
{
    [Fact]
    public void CreateTagEntity_Success()
    {
        var tag = "tag";
        
        var result = TagEntity.Create(tag);

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
        result.Value.TagName.Should().Be(tag);
    }

    [Fact]
    public void CreateTagEntity_Failure()
    {
        var tag = "";

        var result = TagEntity.Create(tag);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().NotBe(Error.None);
        result.Error.Message.Should().Be("Tag input must be not null or not empty");
        Assert.Throws<InvalidOperationException>(() => result.Value);
    }
}
