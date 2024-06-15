﻿using Blog.Domain.Common;
using Blog.Domain.ValueObject;
using CSharpFunctionalExtensions;

namespace Blog.Domain.Entity.Write;
public class UserEntity
{
    private UserEntity() { }    
    private UserEntity(
        string userName,
        EmailAddress email,
        string passwordHash,
        DateTimeOffset registerDate,
        PhoneNumber number)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        RegisterDate = registerDate;
        Phone = number;
    }

    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public EmailAddress Email { get; private set; }
    public string PasswordHash { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public DateTimeOffset RegisterDate { get; private set; }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string SecondName { get; private set; } = string.Empty;
    public DateTimeOffset? BirthDate { get; private set; }

    public static Result<UserEntity, Error> Create(
        string userName,
        string email,
        string passwordHash,
        string phoneNumber)
    {
        userName = userName.Trim().ToLower();
        if (string.IsNullOrEmpty(userName))
            return ErrorFactory.General.InValid("The user name is not valid.");

        var emailResult = EmailAddress.Create(email);
        if (emailResult.IsFailure)
            return emailResult.Error;

        passwordHash = passwordHash.Trim();
        if (string.IsNullOrEmpty(passwordHash))
            return ErrorFactory.General.InValid("The password is not valid");

        var phoneResult = PhoneNumber.Create(phoneNumber);
        if (phoneResult.IsFailure)
            return phoneResult.Error;

        return new UserEntity(userName, emailResult.Value, passwordHash, DateTimeOffset.UtcNow, phoneResult.Value);
    }
}
