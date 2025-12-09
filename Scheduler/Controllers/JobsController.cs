using Akka.Messages;
using AkkaDotNetLearn;
using Microsoft.AspNetCore.Mvc;
using Akka.Actor;
using Akka.Hosting;

namespace Scheduler.Akka.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController(ActorRegistry registry) : ControllerBase
{
    [HttpPost("run")]
    public IActionResult RunJob([FromBody] string payload)
    {
        var jobId = Guid.NewGuid().ToString("N");
        var jobCoordinator = registry.Get<JobCoordinatorActor>();
        jobCoordinator.Tell(new RunJob(jobId, payload));

        return Accepted(new { JobId = jobId, Status = "Queued" });
    }
}