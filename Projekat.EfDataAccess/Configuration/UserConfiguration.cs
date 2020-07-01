using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projekat.Domain;

namespace Projekat.EfDataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
           
        {
            builder.Property(x => x.FirstName)
                .IsRequired();

            builder.Property(x => x.LastName)
               .IsRequired();

            builder.HasIndex(x => x.Email)
               .IsUnique();
            builder.Property(x => x.Email)
              .IsRequired();

            builder.HasIndex(x => x.Password)
             .IsUnique();
            builder.Property(x => x.Password)
              .IsRequired();

            builder.HasIndex(x => x.Username)
             .IsUnique();
            builder.Property(x => x.Username)
              .IsRequired();

           
        }
    }
}
