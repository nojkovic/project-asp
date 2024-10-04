using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class TagConfiguration : NamedEntityConfiguration<Tag>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Tag> builder)
        {
            
        }
    }
}
