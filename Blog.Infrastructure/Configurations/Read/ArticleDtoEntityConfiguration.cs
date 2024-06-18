using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Read;
public class ArticleDtoEntityConfiguration : IEntityTypeConfiguration<ArticleDto>
{
    public void Configure(EntityTypeBuilder<ArticleDto> builder)
    {
        builder.ToTable("articles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("title");
        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnName("description");
        builder.Property(x => x.Text)
            .IsRequired()
            .HasColumnName("text");

        builder.HasOne(a => a.Author)
            .WithMany(u => u.Articles);

        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Article)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Tags)
            .WithMany(t => t.Articles);
    }
}
