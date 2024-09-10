using Blog.Domain.Common;
using FluentAssertions;

namespace Blog.Test.Common;
public class VerifyPropertyTest
{
    [Theory]
    [InlineData("email@email.com")]
    [InlineData("em@email.com")]
    [InlineData("email@em.co")]
    public void VerifyEmail_Success(string input)
    {
        var result = VerifyProperty.VerifyEmail(input);

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }

    [Theory]
    [InlineData("")]
    [InlineData("@email.com")]
    [InlineData("email@.co")]
    [InlineData("email@.")]
    [InlineData("email")]
    public void VerifyEmail_Failure(string input)
    {
        var result = VerifyProperty.VerifyEmail(input);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().NotBe(Error.None);
        result.Error.ErrorCode.Should().Be(ErrorCodes.NotValid);
    }

    [Theory]
    [InlineData("+79998887766")]
    [InlineData("+7(999)8887766")]
    [InlineData("+7(999)888-77-66")]
    [InlineData("+7(999) 888 77 66")]
    [InlineData("89998887766")]
    [InlineData("8(999)888 77 66")]
    [InlineData("9998887766")]
    [InlineData("8887766")]
    public void VerifyPhoneNumber_Success(string input)
    {
        var result = VerifyProperty.VerifyPhoneNumber(input);

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }

    [Theory]
    [InlineData("+19998887766")]
    [InlineData("99998887766")]
    [InlineData("999998887766")]
    [InlineData("string")]
    [InlineData("112233")]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("123")]
    [InlineData("1234")]
    [InlineData("12345")]
    [InlineData("123456")]
    [InlineData("1234567")]
    [InlineData("12345678")]
    [InlineData("123456789")]
    public void VerifyPhoneNumber_Failure(string input)
    {
        var result = VerifyProperty.VerifyPhoneNumber(input);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().NotBe(Error.None);
        result.Error.ErrorCode.Should().Be(ErrorCodes.NotValid);
    }
}
