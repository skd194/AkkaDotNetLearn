using EFCore.Repository.Entities;

namespace Scheduler.Akka.Controllers;

public class JobScheduleRequest
{
    public string Name { get; set; }
    public string TimeZone { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public int MaxRetries { get; set; }
    public int RetryIntervalSeconds { get; set; }
    public bool IsActive { get; set; }
    public JobType JobType { get; set; }
    public int JobId { get; set; }

    // Cron components
    public string Minute { get; set; } = "*";
    public string Hour { get; set; } = "*";
    public string DayOfMonth { get; set; } = "*";
    public string Month { get; set; } = "*";
    public string DayOfWeek { get; set; } = "*";
}
