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
    public class TicketConfig : BaseEntityTypeConfiguration<Ticket,Guid>
    {
        public override void Configure(EntityTypeBuilder<Ticket> builder)
        {

            builder.Property(x=>x.TicketName).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();

            builder.Property(x=>x.price).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(13,3).IsRequired();

            builder.HasOne(x=>x.Category).WithMany(x=>x.Tickets).HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Vehicle).WithMany(x => x.Tickets).HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Residence).WithMany(x => x.Tickets).HasForeignKey(x => x.ResidenceId).OnDelete(DeleteBehavior.NoAction);


            base.RequireTraceable = true;
            base.UseForTraceable = true;
            base.Configure(builder);

        }
    }
}
