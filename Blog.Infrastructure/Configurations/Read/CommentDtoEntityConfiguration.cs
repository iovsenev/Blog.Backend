using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Read;
internal class CommentDtoEntityConfiguration : IEntityTypeConfiguration<CommentReadEntity>
{
    public void Configure(EntityTypeBuilder<CommentReadEntity> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");
        builder.Property(c => c.Content)
            .HasColumnName("content");

        builder.HasOne(c => c.Author)
            .WithMany(u => u.Comments);

        builder.HasOne(c => c.Article)
            .WithMany(a => a.Comments);
    }
}
