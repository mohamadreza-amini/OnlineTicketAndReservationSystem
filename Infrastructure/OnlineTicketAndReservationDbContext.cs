using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OnlineTicketAndReservationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public OnlineTicketAndReservationDbContext() { }
        public OnlineTicketAndReservationDbContext(DbContextOptions<OnlineTicketAndReservationDbContext> dbContext) : base(dbContext) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Category> Category { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OnlineTicket;TrustServerCertificate=True;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
