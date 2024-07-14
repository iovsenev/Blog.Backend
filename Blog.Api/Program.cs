using Blog.Api.Middleware;
using Blog.Application;
using Blog.Domain.Entity.Write;
using Blog.Infrastructure;
using Blog.Infrastructure.DbContexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
    var adminHash = BCrypt.Net.BCrypt.EnhancedHashPassword("admin");

    await dbContext.Database.MigrateAsync();

    var admin = UserEntity.Create("admin@admin.admin", adminHash, "admin", RoleEntity.Admin);
    await dbContext.Users.AddAsync(admin.Value);
    await dbContext.SaveChangesAsync();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
