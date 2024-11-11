using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tableconfigs;

public class VehicleConfig:BaseEntityTypeConfiguration<Vehicle,int> 
{
    public override void Configure(EntityTypeBuilder<Vehicle> builder)
    {

        builder.Property(x=>x.Comapany).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Destination).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Origin).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();
        builder.Property(x => x.VehicleName).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();
        builder.HasOne(x=>x.Category).WithMany().HasForeignKey(x=>x.CategoryId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        ValueGeneratedForKey = true;
        base.Configure(builder);
    }
}
