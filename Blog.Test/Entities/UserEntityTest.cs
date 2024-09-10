using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using FluentAssertions;

namespace Blog.Test.Entities;
public class UserEntityTest
{
    [Fact]
    public void CreateUser_Success()
    {
        var userEmail = "admin@admin.admin";
        var userPassword = "admin";
        var userName = "admin";
        var userRole = RoleEntity.Admin;
        var result = UserEntity.Create(
            userEmail,
            userPassword,
            userName,
            userRole);

        result.IsSuccess.Should().Be(true); 
        result.IsFailure.Should().Be(false);
        result.Error.Should().Be(Error.None);
        result.Value.Should().NotBeNull();
        result.Value.UserName.Should().Be("@"+userName);
        result.Value.Role.Should().Be(userRole);
    }

    [Fact]
    public void CreateUserNonRole_Success()
    {
        var name = "user";
        var password = "userPassword";
        var email = "user@user.user";
        var result = UserEntity.Create(
            email,
            password,
            name);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
        result.Value.Should().NotBeNull();
        result.Value.UserName.Should().Be("@" + name);
        result.Value.Role.Should().Be(RoleEntity.User);
    }

    [Fact]
    public void CreateUserNonRoleNoneName_Success()
    {
        var name = "@someUser";
        var password = "userPassword";
        var email = "someUser@user.user";
        var result = UserEntity.Create(
            email,
            password);

        result.IsSuccess.Should().Be(true);
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
        result.Value.Should().NotBeNull();
        result.Value.UserName.Should().Be(name);
        result.Value.Role.Should().Be(RoleEntity.User);
    }

    [Theory]
    [InlineData("", "", "")]
    [InlineData("emai@email.ru", "", "userName")]
    [InlineData("email", "pass", "userName")]
    [InlineData("emai@email", "pass", "userName")]
    [InlineData("@email.com", "pass", "userName")]
    [InlineData("asda@.com", "pass", "userName")]
    public void CreateUserWithNotCorrectParam(string email, string pass, string userName)
    {

        var result = UserEntity.Create(
            email,
            pass,
            userName);

        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().NotBe(Error.None);
        result.Error.ErrorCode.Should().Be(ErrorCodes.NotValid);
        Assert.Throws<InvalidOperationException>(() => result.Value);
    }
}
