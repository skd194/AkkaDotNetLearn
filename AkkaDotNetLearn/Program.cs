using Akka.Actor;
using Akka.Hosting;
using Akka.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AkkaDotNetLearn
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    // Register Akka.NET with Dependency Injection
                    services.AddAkka("MyActorSystem", (builder, _) =>
                    {
                        builder.WithActors((system, registry) =>
                        {
                            var di = DependencyResolver.For(system);
                            var jobCoordinator = system.ActorOf(di.Props<JobCoordinatorActor>(), "job-coordinator");
                            registry.Register<JobCoordinatorActor>(jobCoordinator);
                        });
                    });
                }).Build();

            await host.RunAsync();
            // await ConsoleAppMain();
        }

        #region Basic Console Appp Testing

        private static async Task ConsoleAppMain()
        {
            var system = ActorSystem.Create("MyActorSystem");

            var echo = await system.RunEchoActorAsync();
            var supervisor = await system.RunIotSupervisorAsync();

            // request graceful shutdown
            await echo.GracefulStop(TimeSpan.FromSeconds(30));
            await supervisor.GracefulStop(TimeSpan.FromSeconds(30));

            await system.Terminate();
        }

        #endregion
    }
}