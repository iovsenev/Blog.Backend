using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

}
