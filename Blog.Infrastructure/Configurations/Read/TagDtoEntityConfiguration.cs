using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Configurations.Read;
public class TagDtoEntityConfiguration : IEntityTypeConfiguration<TagDto>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TagDto> builder)
    {
        builder.ToTable("tags");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("id");
        builder.Property(t => t.TagName)
                .IsRequired()
                .HasColumnName("tag_name");

        builder.HasMany(t => t.Articles)
                .WithMany(t => t.Tags);
    }
}
