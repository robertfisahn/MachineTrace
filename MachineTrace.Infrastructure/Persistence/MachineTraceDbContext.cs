using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Infrastructure.Persistence
{
    public class MachineTraceDbContext : DbContext
    {
        public MachineTraceDbContext(DbContextOptions<MachineTraceDbContext> options) : base(options) { }

        public DbSet<Domain.Entities.Category> Categories { get; set; }
        public DbSet<Domain.Entities.Machine> Machines { get; set; }
        public DbSet<Domain.Entities.Failure> Failures { get; set; }
        public DbSet<Domain.Entities.DailyReport> DailyReports { get; set; }
        public DbSet<Domain.Entities.ServiceReport> ServiceReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Category>()
                .Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired();
            modelBuilder.Entity<Domain.Entities.Machine>(entity =>
            {
                entity.Property(c => c.Name).HasMaxLength(30).IsRequired();
                entity.Property(c => c.Mth).IsRequired();
            });
            modelBuilder.Entity<Domain.Entities.Failure>(entity =>
            {
                entity.Property(c => c.Description).HasMaxLength(200).IsRequired();
                entity.Property(c => c.Mth).IsRequired();

            });
            modelBuilder.Entity<Domain.Entities.DailyReport>(entity =>
            {
                entity.Property(c => c.Mth).IsRequired();
                entity.Property(c => c.Status).IsRequired();
            });
            modelBuilder.Entity<Domain.Entities.ServiceReport>(entity =>
            {
                entity.Property(c => c.Mth).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });
        }

    }
}
