using EFCore.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Repository.EntityConfigurations
{
    internal class JobScheduleConfiguration : IEntityTypeConfiguration<JobSchedule>
    {
        public void Configure(EntityTypeBuilder<JobSchedule> builder)
        {
            builder.HasKey(js => js.Id);
            builder.Property(js => js.Name).IsRequired();
            builder.Property(js => js.JobType).IsRequired();
            builder.Property(js => js.JobId).IsRequired();
            builder.Property(js => js.CronExpression).IsRequired();
            builder.Property(js => js.TimeZone).IsRequired();
            builder.Property(js => js.IsActive).IsRequired();
            builder.Property(js => js.MaxRetries).HasDefaultValue(0);
            builder.Property(js => js.RetryIntervalSeconds).HasDefaultValue(30);
        }
    }
}