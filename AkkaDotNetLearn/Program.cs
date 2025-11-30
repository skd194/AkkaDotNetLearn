using Akka.Actor;

namespace AkkaDotNetLearn
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var system = ActorSystem.Create("MyActorSystem");

            var echo = await system.RunEchoActorAsync();
            var supervisor = await system.RunIotSupervisorAsync();

            // request graceful shutdown
            await echo.GracefulStop(TimeSpan.FromSeconds(30));
            await supervisor.GracefulStop(TimeSpan.FromSeconds(30));

            await system.Terminate();
        }
    }
}