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
    public class UserDataEntityConfiguration : IEntityTypeConfiguration<UserDataEntity>
    {
        public void Configure(EntityTypeBuilder<UserDataEntity> builder)
        {
            builder
                .HasIndex(p => new { p.Code, p.Value});
        }
    }
}
