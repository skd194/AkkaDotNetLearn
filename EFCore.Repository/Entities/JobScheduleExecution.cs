namespace EFCore.Repository.Entities;

public class JobScheduleExecution
{
    public required int Id { get; set; }

    public JobSchedule JobSchedule { get; set; }

    public required DateTimeOffset TriggeredAt { get; set; }

    public int ActionId { get; set; }

    public int RetryAttemptCount { get; set; }

    public required bool IsSuccessful { get; set; }
}