using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Read;
public class UserReadModelConfiguration : IEntityTypeConfiguration<UserReadModel>
{
    public void Configure(EntityTypeBuilder<UserReadModel> builder)
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
            .HasColumnName("email");
        builder.Property(u => u.PasswordHash)
            .HasColumnName("password_hash");
        builder.Property(u => u.UserName)
            .HasColumnName("user_name");
        builder.Property(u => u.RegisterDate)
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
            .WithOne(a => a.Author);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.Author);
    }
}
