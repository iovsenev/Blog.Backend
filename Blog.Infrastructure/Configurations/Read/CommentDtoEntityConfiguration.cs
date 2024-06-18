using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Read;
internal class CommentDtoEntityConfiguration : IEntityTypeConfiguration<CommentDto>
{
    public void Configure(EntityTypeBuilder<CommentDto> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");
        builder.Property(c => c.Text)
            .HasColumnName("text");

        builder.HasOne(c => c.Author)
            .WithMany(u => u.Comments);

        builder.HasOne(c => c.Article)
            .WithMany(a => a.Comments);
    }
}
