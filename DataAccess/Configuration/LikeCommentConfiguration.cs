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
    public class LikeCommentConfiguration : EntityConfiguration<LikeComment>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<LikeComment> builder)
        {
           builder.HasOne(x=>x.User)
                    .WithMany(x => x.LikeComments)
                    .HasForeignKey(x=>x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Comment)
                    .WithMany(x => x.LikeComments)
                    .HasForeignKey(x => x.CommentId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
