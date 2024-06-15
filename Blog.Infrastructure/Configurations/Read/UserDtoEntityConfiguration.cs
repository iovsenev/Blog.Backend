using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Read;
public class UserDtoEntityConfiguration : IEntityTypeConfiguration<UserDto>
{
    public void Configure(EntityTypeBuilder<UserDto> builder)
    {
        builder.ToTable("users");

        builder.HasKey(t => t.Id);

        builder.HasIndex(u => u.UserName)
            .IsUnique();
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Id)
            .HasColumnName("id");
        builder.Property(u => u.UserName)
            .IsRequired()
            .HasColumnName("user_name");
        builder.Property(u => u.Email)
            .IsRequired()
            .HasColumnName("email");
        builder.Property(u => u.Phone)
            .HasColumnName("phone");
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
    }
}
