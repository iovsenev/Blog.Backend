using Blog.Domain.Entity.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Write;
public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");
        builder.Property(c => c.Content)
            .IsRequired()
            .HasColumnName("content");

        builder.HasOne(c => c.Author)
            .WithMany(u => u.Comments);

        builder.HasOne(c => c.Article)
            .WithMany(a => a.Comments);
    }
}
