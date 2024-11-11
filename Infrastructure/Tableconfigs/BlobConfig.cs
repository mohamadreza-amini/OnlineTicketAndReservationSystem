using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tableconfigs
{
    public class BlobConfig :BaseEntityTypeConfiguration<Blob,int>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Blob> builder)
        {

            builder.Property(x => x.FileAddress).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500);
            builder.Property(x => x.MimeType).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500);


            base.ValueGeneratedForKey = true;
            base.Configure(builder);
        }

    }
}
