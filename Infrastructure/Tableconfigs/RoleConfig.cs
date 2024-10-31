using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tableconfigs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.Property(x => x.RolePersianName).IsRequired().HasMaxLength(50).HasColumnType(SqlDbType.NVarChar.ToString());
            builder.Property(x => x.RoleName).IsRequired().HasMaxLength(50).HasColumnType(SqlDbType.VarChar.ToString());
            builder.Property(x => x.RoleDescription).IsRequired(false).HasMaxLength(200).HasColumnType(SqlDbType.VarChar.ToString());

        }
    }
}
