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
    public class PostConfiguration : EntityConfiguration<Post>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x=>x.Text).IsRequired();

            builder.HasOne(x=>x.User)
                    .WithMany(x=>x.Posts)
                    .HasForeignKey(x=>x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
