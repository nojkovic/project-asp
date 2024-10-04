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
    public class PhotoConfiguration : EntityConfiguration<Photo>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(x => x.Path).IsRequired();
            builder.HasOne(x=>x.Post)
                    .WithMany(x=>x.Photos)
                    .HasForeignKey(x=>x.PostId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
