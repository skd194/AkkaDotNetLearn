using EFCore.Repository;
using EFCore.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Controllers;

namespace Scheduler.Akka.Controllers;

[Route("job-schedule")]
[ApiController]
public class JobScheduleController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext _dbContext = dbContext;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] JobScheduleRequest request)
    {
        // Build cron expression from components
        var cronExpression = $"{request.Minute} {request.Hour} {request.DayOfMonth} {request.Month} {request.DayOfWeek}";

        var jobSchedule = new JobSchedule
        {
            Name = request.Name,
            CronExpression = cronExpression,
            TimeZone = request.TimeZone,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            MaxRetries = request.MaxRetries,
            RetryIntervalSeconds = request.RetryIntervalSeconds,
            IsActive = request.IsActive,
            JobType = request.JobType,
            JobId = request.JobId
        };

        _dbContext.JobSchedules.Add(jobSchedule);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(Add), new { id = jobSchedule.Id }, jobSchedule);
    }
}