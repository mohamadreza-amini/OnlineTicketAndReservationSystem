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

public class CategortConfig:BaseEntityTypeConfiguration<Category,int>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.Property(x=>x.CategoryName).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(50).IsRequired();

        base.ValueGeneratedForKey=true;
        base.RequireTraceable=true;
        base.UseForTraceable=true;
        base.Configure(builder);
    }
}
