using Blog.Domain.Entity.Write;
using Blog.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Write;
public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");

        builder.HasKey(t => t.Id);

        builder.HasIndex(u => u.UserName)
            .IsUnique();

        builder.Property(u => u.Id)
            .HasColumnName("id");
        builder.Property(u => u.UserName)
            .IsRequired()
            .HasColumnName("user_name");

        builder.ComplexProperty(u => u.Phone, b =>
        {
            b.Property(p => p.Phone)
            .IsRequired()
            .HasColumnName("phone");
        });

        builder.ComplexProperty(u => u.Email, b =>
        {
            b.Property(e => e.Email)
            .IsRequired()
            .HasColumnName("email");
        });

        builder.Property(u => u.RegisterDate)
            .IsRequired()
            .HasColumnName("register_date");

        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasColumnName("first_name");
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasColumnName("last_name");
        builder.Property(u => u.SecondName)
            .IsRequired()
            .HasColumnName("second_name");
        builder.Property(u => u.BirthDate)
            .HasColumnName("birth_date");

        builder.HasMany(u => u.Articles)
            .WithOne(a => a.Author)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Author)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
