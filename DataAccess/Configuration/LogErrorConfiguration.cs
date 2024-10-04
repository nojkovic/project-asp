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
    public class LogErrorConfiguration : IEntityTypeConfiguration<LogError>
    {
        public void Configure(EntityTypeBuilder<LogError> builder)
    {
        builder.Property(x => x.Message).IsRequired();
        builder.Property(x => x.StrackTrace).IsRequired();

        builder.HasKey(x => x.ErrorId);
    }
}
}
