using EFCore.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Repository.EntityConfigurations;

internal class JobScheduleExecutionConfiguration : IEntityTypeConfiguration<JobScheduleExecution>
{
    public void Configure(EntityTypeBuilder<JobScheduleExecution> builder)
    {
        builder.HasKey(jse => jse.Id);
        builder.Property(jse => jse.TriggeredAt).IsRequired();
        builder.Property(jse => jse.ActionId).IsRequired();
        builder.Property(jse => jse.RetryAttemptCount).IsRequired();
        builder.Property(jse => jse.IsSuccessful).IsRequired();

        builder.HasOne(js => js.JobSchedule)
            .WithMany()
            .HasForeignKey(nameof(JobScheduleExecution.JobSchedule) + "Id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}