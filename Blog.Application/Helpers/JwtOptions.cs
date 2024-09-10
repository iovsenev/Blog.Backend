﻿namespace Blog.Application.Helpers;
public class JwtOptions
{
    public const string Jwt = nameof(JwtOptions);

    public string SecretKey { get; init; } = string.Empty;

    public int Expires { get; init; }
}
