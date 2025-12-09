using Akka.Actor;
using Akka.Messages;
using Microsoft.Extensions.Logging;

namespace AkkaDotNetLearn;

public class JobCoordinatorActor : ReceiveActor
{
    private readonly ILogger<JobCoordinatorActor> _logger;

    public JobCoordinatorActor(ILogger<JobCoordinatorActor> logger)
    {
        _logger = logger;
        Receive<RunJob>(job =>
        {
            Context.ActorOf(Props.Create(() => new JobWorkerActor(job.JobId))).Tell(job);
        });
    }
}