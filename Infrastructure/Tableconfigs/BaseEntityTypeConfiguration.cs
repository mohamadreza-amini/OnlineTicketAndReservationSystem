using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Infrastructure.Tableconfigs
{
    public class BaseEntityTypeConfiguration<T, KeyTypeId> : IEntityTypeConfiguration<T> where T : BaseEntity <KeyTypeId> where KeyTypeId : struct
    {
        protected bool ValueGeneratedForKey { get; set; } = false;
        protected bool UseForTraceable { get; set; } = false;
        protected bool RequireTraceable { get; set; } = false;
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            if (ValueGeneratedForKey)
                builder.Property(x => x.Id).ValueGeneratedOnAdd();

            if (!UseForTraceable)
            {
                builder.Ignore(x => x.CreatedUser);
                builder.Ignore(x => x.CreatedUserId);
                builder.Ignore(x => x.UpdatedUser);
                builder.Ignore(x => x.UpdatedUserId);
                builder.Ignore(x => x.CreatedDateTime);
                builder.Ignore(x => x.UpdatedDateTime);
            }
            else
            {
                builder.Property(x => x.CreatedDateTime).IsRequired(RequireTraceable);
                builder.Property(x => x.UpdatedDateTime).IsRequired(RequireTraceable);

                builder.HasOne(x => x.CreatedUser).WithMany().HasForeignKey(x => x.CreatedUserId).IsRequired(RequireTraceable).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(x => x.UpdatedUser).WithMany().HasForeignKey(y => y.UpdatedUserId).IsRequired(RequireTraceable).OnDelete(DeleteBehavior.NoAction);

            }

        }
    }
}
