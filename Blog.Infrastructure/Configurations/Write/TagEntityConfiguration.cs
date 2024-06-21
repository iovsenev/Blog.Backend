using Blog.Domain.Entity.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Write;
public class TagEntityConfiguration : IEntityTypeConfiguration<TagEntity>
{
    public void Configure(EntityTypeBuilder<TagEntity> builder)
    {
        builder.ToTable("tags");

        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.TagName)
            .IsUnique();

        builder.Property(t =>t.Id)
            .IsRequired()
            .HasColumnName("id");
        builder.Property(t => t.TagName)
            .IsRequired()
            .HasColumnName("tag_name");

        builder.HasMany(t => t.Articles)
            .WithMany(t => t.Tags);
    }
}
