﻿using Blog.Domain.Entity.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations.Write;
public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(x => x.Name);

        builder.Property(x => x.Name)
            //.IsRequired()
            .HasColumnName("name");
    }
}
