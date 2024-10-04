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
    public class UseCaseLogConfiguration : EntityConfiguration<UseCaseLog>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UseCaseLog> builder)
        {
            builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.Property(x => x.UseCaseName).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => new { x.Username, x.UseCaseName, x.ExecutedAt })
                   .IncludeProperties(x => x.UseCaseData);
        }
    }
}
