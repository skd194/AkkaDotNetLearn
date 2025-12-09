using Akka.Actor;
using Akka.Messages;

namespace AkkaDotNetLearn;

public class JobWorkerActor : ReceiveActor
{
    private readonly string _jobId;


    public JobWorkerActor(string jobId)
    {
        _jobId = jobId;

        ReceiveAsync<RunJob>(HandleRunJobAsync);
    }

    private async Task HandleRunJobAsync(RunJob msg)
    {
        try
        {
            // Simulate a long-running background task
            await Task.Delay(TimeSpan.FromSeconds(5));

            Console.WriteLine($"[JobWorker] Job {_jobId} completed. Payload: {msg.Payload}");

            // Notify completion (to parent, DB, etc.)
            Context.Parent.Tell(new JobCompleted(_jobId));

            // Stop this worker
            Context.Stop(Self);
        }
        catch (Exception ex)
        {
            Context.Parent.Tell(new JobFailed(_jobId, ex));
            Context.Stop(Self);
        }
    }
}