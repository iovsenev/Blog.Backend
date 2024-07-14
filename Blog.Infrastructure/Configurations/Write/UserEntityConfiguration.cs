using Blog.Domain.Entity.Write;
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
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Id)
            .HasColumnName("id");
        builder.Property(u => u.Email)
            .IsRequired()
            .HasColumnName("email");
        builder.Property(u => u.PasswordHash)
            .HasColumnName("password_hash")
            .IsRequired();
        builder.Property(u => u.UserName)
            .IsRequired()
            .HasColumnName("user_name");
        builder.Property(u => u.RegisterDate)
            .IsRequired()
            .HasColumnName("register_date");

        builder.Property(u => u.PhoneNumber)
            .HasColumnName("Phone_number");
        builder.Property(u => u.FirstName)
            .HasColumnName("first_name");
        builder.Property(u => u.LastName)
            .HasColumnName("last_name");
        builder.Property(u => u.SecondName)
            .HasColumnName("second_name");
        builder.Property(u => u.BirthDate)
            .HasColumnName("birth_date");

        builder.ComplexProperty(u => u.Address, b =>
        {
            b.Property(a => a.Country).HasColumnName("country");
            b.Property(a => a.City).HasColumnName("city");
        });

        builder.HasMany(u => u.Articles)
            .WithOne(a => a.Author)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Author)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(u => u.Role)
            .WithMany();
    }
}
