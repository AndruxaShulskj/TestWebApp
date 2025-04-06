using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApp.DataAccess.Entities;

namespace TestWebApp.DataAccess.EntitiesConfigurations
{
    public class LogEntityConfiguration : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.HasIndex(p => new { p.Date, p.Code, p.Duration});
        }
    }
}
