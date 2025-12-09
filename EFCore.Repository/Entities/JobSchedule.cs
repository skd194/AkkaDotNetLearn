namespace EFCore.Repository.Entities;

public class JobSchedule
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public JobType JobType { get; set; }

    public int JobId { get; set; }

    public required string CronExpression { get; set; }

    public required string TimeZone { get; set; }

    public DateTimeOffset? StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public int MaxRetries { get; set; }

    public int RetryIntervalSeconds { get; set; }

    public bool IsActive { get; set; }
}