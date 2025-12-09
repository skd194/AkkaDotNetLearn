using EFCore.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<JobSchedule> JobSchedules { get; set; }

        public DbSet<JobScheduleExecution> JobScheduleExecutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplySingularTableNames(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        private void ApplySingularTableNames(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Use the class name (singular) as table name
                entity.SetTableName(entity.ClrType.Name);
            }
        }
    }
}