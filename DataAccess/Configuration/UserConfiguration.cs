using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class UserConfiguration : NamedEntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {

            builder.Property(x=>x.Username)
                    .IsRequired()
                    .HasMaxLength(40);

            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x=>x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x=>x.Password).IsRequired();

            


        }
    }
}
