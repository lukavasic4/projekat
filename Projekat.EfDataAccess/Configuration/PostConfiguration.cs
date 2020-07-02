using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projekat.Domain;

namespace Projekat.EfDataAccess.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired();
            builder.HasIndex(x => x.Title)
                .IsUnique();

            builder.Property(x => x.Text)
                .IsRequired();
                
            builder.HasMany(p => p.CategoryPost).WithOne(cp => cp.Post).HasForeignKey(cp => cp.PostId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
