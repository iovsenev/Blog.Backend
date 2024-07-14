using Blog.Domain.Entity.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Read;
public class ArticleReadModelConfiguration : IEntityTypeConfiguration<ArticleReadModel>
{
    public void Configure(EntityTypeBuilder<ArticleReadModel> builder)
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

        builder.Property(x => x.Content)
            .IsRequired()
            .HasColumnName("content");

        builder.Property(a => a.CreatedDate)
            .HasColumnName("created_at");

        builder.Property(a => a.Rating)
            .HasColumnName("rating");

        builder.Property(a => a.IsPublished)
            .HasColumnName("is_pablished");

        builder.Property(a => a.UnderInspection)
            .HasColumnName("under_inspection");

        builder.HasOne(a => a.Author)
            .WithMany(u => u.Articles);

        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Article);

        builder.HasMany(a => a.Tags)
            .WithMany(t => t.Articles);
    }
}