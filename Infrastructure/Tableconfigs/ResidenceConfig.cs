using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tableconfigs;

public class ResidenceConfig:BaseEntityTypeConfiguration<Residence,int>
{
    public override void Configure(EntityTypeBuilder<Residence> builder)
    {

        builder.Property(x => x.Address).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Name).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Star).HasColumnType(SqlDbType.TinyInt.ToString()).HasMaxLength(100).IsRequired();
        builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        ValueGeneratedForKey = true;
        base.Configure(builder);
    }
}   
