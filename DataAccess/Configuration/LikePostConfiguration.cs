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
    public class LikePostConfiguration : EntityConfiguration<LikePost>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<LikePost> builder)
        {
            builder.HasOne(x=>x.User)
                    .WithMany(x=>x.LikePosts)
                    .HasForeignKey(x=>x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Post)
                    .WithMany(x => x.LikePosts)
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TypeLike)
                    .WithMany(x => x.LikePosts)
                    .HasForeignKey(x => x.TypeLikeId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
