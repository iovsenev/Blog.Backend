using Blog.Domain.Entity.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Write;
public class ArticleEntityConfiguration : IEntityTypeConfiguration<ArticleEntity>
{
    public void Configure(EntityTypeBuilder<ArticleEntity> builder)
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
            .IsRequired()
            .HasDefaultValue(0)
            .HasColumnType("decimal")
            .HasColumnName("rating");

        builder.Property(a => a.IsPublished)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnType("boolean")
            .HasColumnName("is_pablished");

        builder.Property(a => a.UnderInspection)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnType("boolean")
            .HasColumnName("under_inspection");


        builder.HasOne(a => a.Author)
            .WithMany(u => u.Articles);

        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Article)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Tags)
            .WithMany(t => t.Articles);
    }
}
